using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class master : MonoBehaviour
{
    public GameScreen screen;

    public PlayerDeck Deck;
    public List<Card> startingDeck;
    public List<Card> masterDeckList;

    // card offer pool is a pool of every cards that could be added to deck.
    public List<Card> cardOfferPool;
    //card shop is card offer pool split by card level
    public List<Card> cardShopT1;
    public List<Card> cardShopT2;
    public List<Card> cardShopT3;
    //locked cards need to be unlocked and moved to card shop+cardOfferPool before they can be added to a deck
    public List<Card> cardLockedT1;
    public List<Card> cardLockedT2;
    public List<Card> cardLockedT3;

    public int redCost1 = 1;
    public int blueCost1 = 1;
    public int yellowCost1 = 1;
    public int coinCost1 = 2;

    public PlayZone Offering;
    public PlayerDiscard DiscardPile;
    public CardEng cardEng;
    public Bank StartingBank;
    public Bank CurrentBank;
    public Bank NextBank;
    public BankUi bankUi;

    public int factoryDumpCost = 0;
    public TMP_Text factoryDumpUi;

    public bool readyToStartNextTurn = false;
    public int turn = 1;
    public int score = 0;
    public int gameCount = 0;
    public int level = 1;
    public TMP_Text TurnUi;

    public TMP_Text Text_games;
    public TMP_Text Text_score;
    public TMP_Text Text_Level;

    public Canvas ListCanvas;
    public ListController listController;

    public Canvas optionCavas;
    public ListController optionlistController;

    public Canvas choiceCanvas;
    public ListController choicelistController;

    public Canvas EventUI;
    //Public EventContorler eventControler;

    public ShopControler shopControler;

    public Canvas ShopScoreWindow;
    public TMP_Text PostGameScoreTitle;
    public TMP_Text PostGameScoreStats;

 
    void Start()
    {
        Loadgame();
        LoadScene();
        if (SceneManager.GetActiveScene().name == "game1")
        {
            Loadgame();
            screen = GameScreen.GameBoard;
            SetUpGameBank();
            if (startingDeck == null) 
            {
                print("first time load fired");
                FirstTimeDeckSetup();
            }
            if (turn == 1)
            {
                masterDeckList.Clear();
                masterDeckList.AddRange(startingDeck);
            }
            UpdateTurnCountUi();
            Deck.DeckSetup(masterDeckList);
            Offering.HaveCardZonesGetCards();                       
        }
        else if (screen == GameScreen.Store)
        {
            Loadgame();
            SetUpShopBank();
            LoadShopOffers();
            LoadPostGameScore();

        }
        else if (screen == GameScreen.MainMenu)
        {
            Loadgame();
            if (startingDeck == null)
            {
                print("first time load fired");
                FirstTimeDeckSetup();
            }
            SetStatsText();
        }
    }

    public void StartGameFromMainMenu() 
    {
        screen = GameScreen.Store;
        SceneManager.LoadScene("game1");

    }

    void SetUpGameBank()
    {
        bankUi.thisTurnBank = CurrentBank;
        bankUi.coinBank = CurrentBank;
        bankUi.nextTurnBank = NextBank;
        if (turn == 1)
        {
            CurrentBank.ClearBank();
            NextBank.ClearBank();
            CurrentBank.TranferValues(StartingBank);
        }

        bankUi.UpdateUI();
        Debug.Log("bank" + CurrentBank.Blue);
    }


    void SetUpShopBank()
    {
        bankUi.nextTurnBank = StartingBank;
        bankUi.thisTurnBank = StartingBank;
        bankUi.coinBank = CurrentBank;
        NextBank = StartingBank;
        bankUi.UpdateUI();
    }


    public void FirstTimeDeckSetup()
    {                                       
        masterDeckList = new List<Card>();
        startingDeck = new List<Card>();
        cardOfferPool = new List<Card>();        
        cardShopT1 = new List<Card>();
        cardShopT2 = new List<Card>();
        cardShopT3 = new List<Card>();        
        cardLockedT1 = new List<Card>();
        cardLockedT2 = new List<Card>();
        cardLockedT3 = new List<Card>();
        
        masterDeckList.AddRange(cardHolder.BasicCards(cardEng, this));
        startingDeck.AddRange(masterDeckList);        
        cardLockedT1.AddRange(cardHolder.Level1LockCards(cardEng, this));
        cardShopT1.AddRange(cardHolder.Level1ShopCards(cardEng, this));
        cardOfferPool.AddRange(cardShopT1);
    }


    //startingDeck
    public void StartTurn()
    {
        if (readyToStartNextTurn)
        {
            Deck.DeckSetup(masterDeckList);
            SaveGame();
            Offering.HaveCardZonesGetCards();
            UpdateTurnCountUi();
            factoryDumpCost = 0;
            factoryDumpUi.text = string.Format("Cost:{0}", factoryDumpCost);
            bankUi.UpdateUI();
            readyToStartNextTurn = false;
        }
    }
    
    public void BetweenTurnUpgrade()
    {
        // load some items
        // basic option upgrade. Trash or Upgrade ( or get a random charm)
        //listController.LoadList(Deck.Cards);
        
        if (turn == 1)
        {
            //        listController.LoadList(cardOfferPool, true, ClickEffect.newFactory, zone, false, true, 3);

            OfferCard(Zones.master);
        }

        else if (turn == 2 || turn == 3)
        {
            optionlistController.LoadList(cardHolder.Options(cardEng, this), false, ClickEffect.option);
            optionCavas.gameObject.SetActive(true);
        }
        else if (turn == 4)
        {
            EventUI.gameObject.SetActive(true);            
        }
    
    }

    public void EndTurn()
    {
        if (turn == 5)
        {
            print("end game");
            Offering.CleanUpCardSlots();

            CurrentBank.TranferValues(NextBank);
            //save score and coins
            score += CurrentBank.GetBankSum();
            gameCount++;
            turn = 1;
            screen = GameScreen.Store;
            SaveGame();
            //load shop 

            SceneManager.LoadScene("Shop");


        }
        else
        {
            Offering.CleanUpCardSlots();
            DiscardPile.DiscardSetup();
            CurrentBank.TranferValues(NextBank);
            NextBank.ClearBank();
            //offer upgrade
            BetweenTurnUpgrade();
            readyToStartNextTurn = true;
            //start the next turn.
        }
        turn++;

    }
    public void UpdateTurnCountUi()
    {

        TurnUi.text = string.Format("{0}/5", turn);
        if (turn == 5)
        {
            TurnUi.text = string.Format("Last Turn!");
        }
        if (turn > 5)
        {
            TurnUi.text = string.Format("End Of Game");
        }
    }
    public void DiscardFactorys()
    {
        if (CurrentBank.Transaction(Currency.coin, factoryDumpCost * -1))
        {
            Offering.HaveCardZonesDisardCards();
            Offering.HaveCardZonesGetCards();
            factoryDumpCost++;
            factoryDumpUi.text = string.Format("Cost:{0}", factoryDumpCost);
            bankUi.UpdateUI();
        }
    }   
    public void OpenDeckUI() 
    {
        listController.LoadList(Deck.Cards);
        ListCanvas.gameObject.SetActive(true);
    }
    public void OpenDiscardUI()
    {
        listController.LoadList(DiscardPile.Cards,false);
        ListCanvas.gameObject.SetActive(true);
    }
    public void OpenMasterDeckUI()
    {
        listController.LoadList(masterDeckList,false);
        ListCanvas.gameObject.SetActive(true);
    }
    public void OpenStartingeckUI()
    {
        listController.LoadList(startingDeck, false);
        ListCanvas.gameObject.SetActive(true);
    }
    public void OpenStartingUpgradesCards()
    {
        listController.LoadList(cardHolder.BasicUpgradeCards(cardEng, this), false);
        ListCanvas.gameObject.SetActive(true);
    }
    public void OpenOfferPoolUI()
    {
        listController.LoadList(cardOfferPool, false);
        ListCanvas.gameObject.SetActive(true);
    }
    public void OpenAllCardsUI()
    {
        listController.LoadList(cardHolder.LoadAllCards(cardEng, this), false);
        ListCanvas.gameObject.SetActive(true);
    }
    public void OpenLevel1LockedCards()
    {
        listController.LoadList(cardHolder.Level1LockCards(cardEng, this), false);
        ListCanvas.gameObject.SetActive(true);
    }
    public void OpenLevel1ShopCards()
    {
        listController.LoadList(cardHolder.Level1ShopCards(cardEng, this), false);
        ListCanvas.gameObject.SetActive(true);
    }
    public void OpenLevel1UpgradeCards()
    {
        listController.LoadList(cardHolder.Level1UpgradeCards(cardEng, this), false);
        ListCanvas.gameObject.SetActive(true);
    }


    public void OpenTrashUI(Zones zone)
    {
        print("open Trash UI");
        switch (zone)
        {
            case (Zones.master):
                choicelistController.LoadList(masterDeckList,false,ClickEffect.trash,zone);
                    break;
            case (Zones.discard):
                choicelistController.LoadList(DiscardPile.Cards, false, ClickEffect.trash, zone);
                break;
            case (Zones.deck):
                choicelistController.LoadList(Deck.Cards, false, ClickEffect.trash, zone);
                break;
            case (Zones.deckAndDiscard):
                choicelistController.LoadList(DiscardPile.Cards, false, ClickEffect.trash, zone);
                choicelistController.LoadList(Deck.Cards, false, ClickEffect.trash, zone);
                break;

        }
        choiceCanvas.gameObject.SetActive(true);
    }

    public void OpenUpgradeUI(Zones zone)
    {
        print("open Upgrade UI");
        switch (zone)
        {
            case (Zones.master):
                choicelistController.LoadList(masterDeckList, false, ClickEffect.upgrade, zone);
                break;
            case (Zones.deck):
                choicelistController.LoadList(Deck.Cards, false, ClickEffect.upgrade, zone);
                break;
            case (Zones.discard):
                choicelistController.LoadList(DiscardPile.Cards, false, ClickEffect.upgrade, zone);
                break;
            case (Zones.deckAndDiscard):
                choicelistController.LoadList(Deck.Cards, false, ClickEffect.upgrade, zone);
                choicelistController.LoadList(DiscardPile.Cards, false, ClickEffect.upgrade, zone);
                break;

        }
        choiceCanvas.gameObject.SetActive(true);
    }
    public void SetStatsText() 
    {

        Text_games.text = "Games Played: " +gameCount;
        Text_score.text = "Score: " + score;
        Text_Level.text = "Level: " + level;
    
    }
    public void CloseAllUI()
    {
        listController.CloseUI();
        choicelistController.CloseUI();
        optionlistController.CloseUI();
        Offering.HaveCardZonesGetCards();
        StartTurn();
    }
   
    public void LoadShopOffers()
    {
        int shopsize1 = 3;
        if (level>19) 
        { 
        }
        if (level>9)
        {

        }
   //     ListController shop1 = shopControler.LoadShop();
    //    shop1.UiText.text = "Unlock Cards";
    //    shop1.LoadList(cardLockedT1,true,ClickEffect.unlock,Zones.shop1,true,false, shopsize1);
        ListController shop2 = shopControler.LoadShop();
        shop2.UiText.text = "Buy Factory for starting deck";
        shop2.LoadList(cardShopT1, true, ClickEffect.shop, Zones.startingDeck, true,false, shopsize1);
        ListController shop3 = shopControler.LoadShop();
        shop3.UiText.text = "Buy More starting Resources";
        shop3.LoadList(cardHolder.ResorceCards(cardEng, this), false, ClickEffect.resorce, Zones.shop1, true,false);
    }

    public void LoadPostGameScore()
    {
        PostGameScoreTitle.text = "Score for Game: " + gameCount;
        PostGameScoreStats.text = string.Format( "Score: {0} \n Level: {1} \n To Next Level {2}" ,CurrentBank.GetBankSum(),level,999);
        ShopScoreWindow.gameObject.SetActive(true);
    }

    public void OfferCard(Zones zone)
    {
        listController.LoadList(cardOfferPool, true, ClickEffect.newFactory, zone, false, true, 3);
        ListCanvas.gameObject.SetActive(true);
    }
    // why is this in master. 
    public void UnlockCard(Zones zone, Card card) 
    {
        switch (zone) 
        {
            case Zones.shop1:
                AddCard(zone, card);
                RemoveCard(Zones.lock1, card); 
                break;
            case Zones.shop2:
                AddCard(zone, card);
                RemoveCard(Zones.lock2, card);
                break;
            case Zones.shop3:
                AddCard(zone, card);
                RemoveCard(Zones.lock3, card);
                break;

        }
        LoadCardIntoOfferPool(card);
    }
    public void RemoveCard(Zones zone, Card card)
    {
        switch (zone)
        {
            case (Zones.master):
                masterDeckList.Remove(card);
                DiscardPile.Cards.Remove(card);
                masterDeckList.Remove(card);
                break;
            case (Zones.lock1):
                cardLockedT1.Remove(card);
                break;
            case (Zones.lock2):
                cardLockedT2.Remove(card);
                break;
            case (Zones.lock3):
                cardLockedT3.Remove(card);
                break;
            case (Zones.deck):
                Deck.Cards.Remove(card);
                masterDeckList.Remove(card);
                break;
            case (Zones.discard):
                DiscardPile.Cards.Remove(card);
                masterDeckList.Remove(card);
                break;          
        }
    }
    public void AddCard(Zones zone, Card card)
    {
        switch (zone)
        {
            case (Zones.master):
                masterDeckList.Add(card);
                CloseAllUI();
                break;
            case (Zones.shop1):
                cardShopT1.Add(card);
                    break;
            case (Zones.shop2):
                cardShopT2.Add(card);
                break;
            case (Zones.shop3):
                cardShopT3.Add(card);
                break;
            case (Zones.startingDeck):
                startingDeck.Add(card);
                break;
            case (Zones.deck):
                masterDeckList.Add(card);
                Deck.Cards.Add(card);
                CloseAllUI();
                break;
            case (Zones.discard):
                masterDeckList.Add(card);
                DiscardPile.Cards.Add(card);
                CloseAllUI();
                break;
        }
    }
    public void LoadCardIntoOfferPool(Card card) 
    {
        cardOfferPool.Add(card);    
    }    
    public void SaveGame() 
    {        
        GameSaver.SaveGame(CurrentBank, StartingBank, startingDeck, cardOfferPool, turn, score, gameCount, level, masterDeckList, Deck.Cards,
            cardShopT1, cardShopT2, cardShopT3, cardLockedT1, cardLockedT2, cardLockedT3,redCost1,blueCost1,yellowCost1,coinCost1,screen);
    }
    public void ExitShop()
    {
        screen = GameScreen.MainMenu;
        SaveGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void DeleteSaveData() 
    {
        DataSaver.deleteData("data");
        gameCount = 0;
        score = 0;
        level = 0;
    }

    public void LoadScene()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        print(screen);
        switch (screen) 
        {
            case GameScreen.MainMenu:
                break;
            case GameScreen.GameBoard:
                if (SceneManager.GetActiveScene().name != "game1")
                {
                    SceneManager.LoadScene("game1");
                }
                break;
            case GameScreen.Store:
                if (SceneManager.GetActiveScene().name != "Shop")
                {
                    SceneManager.LoadScene("Shop");
                }
                break;
        }
    }

    public void Loadgame()
    {
        PlayerData playerdata = DataSaver.loadData<PlayerData>("data");
        if (playerdata == null)
        {
            cardEng = new CardEng(CurrentBank, NextBank, bankUi);
        }
        else
        {
            StartingBank = playerdata.startingBank;
            CurrentBank = playerdata.curentBank;
            gameCount = playerdata.gameCount;
            score = playerdata.score;
            level = playerdata.level;
            turn = playerdata.curentTurn;
            cardEng = new CardEng(CurrentBank, NextBank, bankUi);

            masterDeckList = GameSaver.StringsToCards(playerdata.masterDeck, cardEng, this);
            startingDeck = GameSaver.StringsToCards(playerdata.startingDeck, cardEng, this);
            Deck.Cards = GameSaver.StringsToCards(playerdata.myDeck, cardEng, this);

            cardOfferPool = GameSaver.StringsToCards(playerdata.offerPool, cardEng, this);
            cardShopT1 = GameSaver.StringsToCards(playerdata.cardShopT1, cardEng, this);
            cardShopT2 = GameSaver.StringsToCards(playerdata.cardShopT2, cardEng, this);
            cardShopT3 = GameSaver.StringsToCards(playerdata.cardShopT3, cardEng, this);
            cardLockedT1 = GameSaver.StringsToCards(playerdata.cardLockedT1, cardEng, this);
            cardLockedT2 = GameSaver.StringsToCards(playerdata.cardLockedT2, cardEng, this);
            cardLockedT3 = GameSaver.StringsToCards(playerdata.cardLockedT3, cardEng, this);

            redCost1 = playerdata.redCost1;
            blueCost1 = playerdata.blueCost1;
            yellowCost1 = playerdata.yellowCost1;
            coinCost1 = playerdata.coinCost1;
            screen = playerdata.gameScreen;
        }
    }

}
public enum GameScreen
{ 
    MainMenu,
    GameBoard,
    Store

}


  
 

