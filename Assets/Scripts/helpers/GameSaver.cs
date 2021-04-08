using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSaver 
{


    public static void SaveGame(Bank bank, Bank startingBank, List<Card> startingDeck,List<Card>offerPool,int turn,int score,int gameCount,int level,List<Card>masterDeck,List<Card> deck,
        List<Card> shop1,List<Card> shop2, List<Card> shop3, List<Card> lock1, List<Card> lock2, List<Card> lock3,int red1,int blue1,int yellow1,int coin1, GameScreen screen)   
    {

        PlayerData saveData = new PlayerData();

        saveData.curentBank = bank;
        saveData.startingBank = startingBank;
        saveData.coins = bank.Coin;
        
        saveData.masterDeck.AddRange(CardsToStrings(masterDeck));
        saveData.myDeck.AddRange(CardsToStrings(deck));
        saveData.startingDeck.AddRange(CardsToStrings(startingDeck));
        saveData.offerPool.AddRange(CardsToStrings(offerPool));

        saveData.cardShopT1.AddRange(CardsToStrings(shop1));
        saveData.cardShopT2.AddRange(CardsToStrings(shop2));
        saveData.cardShopT3.AddRange(CardsToStrings(shop3));

        saveData.cardLockedT1.AddRange(CardsToStrings(lock1));
        saveData.cardLockedT2.AddRange(CardsToStrings(lock2));
        saveData.cardLockedT3.AddRange(CardsToStrings(lock3));

        saveData.curentTurn = turn;
        saveData.score = score;
        saveData.level = level;
        saveData.gameCount = gameCount;

        saveData.redCost1 = red1;
        saveData.blueCost1 = blue1;
        saveData.yellowCost1 = yellow1;
        saveData.coinCost1 = coin1;

        saveData.gameScreen = screen;

        DataSaver.saveData(saveData,"data");

    }


    public static List<string> CardsToStrings(List<Card> cards)
    {
        List<string> cardNames = new List<string>();
        Debug.Log(cards.Count);
        foreach (Card card in cards)
        {
            cardNames.Add(card.cardName);
        }

        return cardNames;
    }

    public static List<Card> StringsToCards(List<string> cardNames, CardEng cardEng, master master)
    {
         List<Card> cards = new List<Card>();

        foreach (string cardName in cardNames)
        {
            cards.Add(cardHolder.GetCardByCardName(cardName, cardEng, master));
        }
        return cards;                      
    }
}

/*

public List<Card> masterDeck = new List<Card>();
public List<Card> myDeck = new List<Card>();
public List<Card> startingDeck = new List<Card>();
public List<Card> offerPool = new List<Card>();

public Bank curentBank = new Bank(new BankUi());
public Bank startingBank = new Bank(new BankUi());

public int curentTurn = 0;
public int coins = 0;
public int score = 0;
public int gameCount = 0;
*/