using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public static class cardHolder 
{

    // wow this lookup looks costly prob should set it up once somewhere on load. 
    public static Card GetCardByCardName(string cardName,CardEng eng, master master) 
    {
        List<Card> allCards = LoadAllCards(eng, master);
        foreach (Card card in allCards) 
        { 
        if(cardName == card.cardName)
            {
                return card;
            }
        }

        Debug.LogError("Failed to find card: " + cardName);
        return new PlaceHolderCard();
    }
    // dont load options and resorce to 'all cards list'
    public static List<Card> LoadAllCards(CardEng cardEng, master master)
    {
        List<Card> allCards = new List<Card>();

        allCards.AddRange(BasicCards(cardEng, master));
        allCards.AddRange(BasicUpgradeCards(cardEng, master));
        allCards.AddRange(Level1ShopCards(cardEng, master));
        allCards.AddRange(Level2ShopCards(cardEng, master));
        allCards.AddRange(Level3ShopCards(cardEng, master));
        allCards.AddRange(Level1LockCards(cardEng, master));
        allCards.AddRange(Level2LockCards(cardEng, master));
        allCards.AddRange(Level3LockCards(cardEng, master));
        allCards.AddRange(Level1UpgradeCards(cardEng, master));
        allCards.AddRange(Level2UpgradeCards(cardEng, master));
        allCards.AddRange(Level3UpgradeCards(cardEng, master));

        return allCards;
    }
    public static List<Card> Options(CardEng cardEng,master master)
    {
        List<Card> options = new List<Card>();
        options.Add(new TrashOption(cardEng, master));
        options.Add(new UpgradeOption(cardEng, master));
        return options;
    }
    public static List<Card> ResorceCards(CardEng cardEng, master master)
    {
        List<Card> cards = new List<Card>();
        cards.Add(new RedResource(cardEng, master));
        cards.Add(new BlueResource(cardEng, master));
        cards.Add(new YellowResource(cardEng, master));
        cards.Add(new CoinResource(cardEng, master));
        return cards;
    }
    public static List<Card> BasicCards(CardEng cardEng, master master) 
    
    {
        List<Card> basicCards = new List<Card>();
        basicCards.Add(new RedToBlueFactory1(cardEng, master));
        basicCards.Add(new BlueToYellow1(cardEng, master));
        basicCards.Add(new YellowToRed1(cardEng, master));
        basicCards.Add(new YellowToCoin1(cardEng, master));
        basicCards.Add(new FreeToEach1(cardEng, master));
        basicCards.Add(new FreeToRed1(cardEng, master));
        basicCards.Add(new RBYToCoin1(cardEng, master));
        basicCards.Add(new BlueToFactory1(cardEng, master));
        basicCards.Add(new RedToTrash1(cardEng, master));
        basicCards.Add(new YellowToUpgrade1(cardEng, master));
        return basicCards;
    }
    public static List<Card> BasicUpgradeCards(CardEng cardEng, master master) 
    {
        List<Card> BasicUpgradeCards = new List<Card>();

        BasicUpgradeCards.Add(new BlueToFactory2(cardEng, master));
        BasicUpgradeCards.Add(new BlueToYellow2(cardEng, master));
        BasicUpgradeCards.Add(new FreeToEach2(cardEng, master));
        BasicUpgradeCards.Add(new FreeToRed2(cardEng, master));
        BasicUpgradeCards.Add(new RBYToCoin2(cardEng, master));
        BasicUpgradeCards.Add(new RedToBlue2(cardEng, master));
        BasicUpgradeCards.Add(new RedToTrash2(cardEng, master));
        BasicUpgradeCards.Add(new YellowToCoin2(cardEng, master));
        BasicUpgradeCards.Add(new YellowToRed2(cardEng, master));
        BasicUpgradeCards.Add(new YellowToUpgrade2(cardEng, master));
        return BasicUpgradeCards;
    }
    public static List<Card> Level1LockCards(CardEng cardEng, master master) 
    {
        List<Card> cards = new List<Card>();
        cards.Add(new FreeToRed2(cardEng, master));
        cards.Add(new FreeToBlue1(cardEng, master));
        cards.Add(new FreeToYellow1(cardEng, master));
        cards.Add(new CoinToEach1(cardEng, master));
        cards.Add(new RBToCoin1(cardEng, master));

        return cards;
    }
    public static List<Card> Level1ShopCards(CardEng cardEng, master master)
    {
        List<Card> cards = new List<Card>();
        cards.Add(new BlueToRed1(cardEng, master));
        cards.Add(new RedToYellow1(cardEng, master));
        cards.Add(new YellowToBlue1(cardEng, master));
        cards.Add(new RedToBlue3(cardEng, master));
        cards.Add(new BlueToYellow3(cardEng, master));
        return cards;
    }
    public static List<Card> Level1UpgradeCards(CardEng cardEng, master master)
    {
        List<Card> cards = new List<Card>();
        cards.Add(new BlueToRed2(cardEng, master));
        cards.Add(new BlueToYellow4(cardEng, master));
        cards.Add(new CoinToEach2(cardEng, master));
        cards.Add(new FreeToBlue2(cardEng, master));
        cards.Add(new FreeToYellow2(cardEng, master));
        cards.Add(new RBToCoin2(cardEng, master));
        cards.Add(new RedToBlue4(cardEng, master));
        cards.Add(new RedToYellow2(cardEng, master));
        cards.Add(new YellowToBlue2(cardEng, master));                
        return cards;

    }
    public static List<Card> Level2LockCards(CardEng cardEng, master master)
    {
        List<Card> cards = new List<Card>();
        return cards;
    }
    public static List<Card> Level2ShopCards(CardEng cardEng, master master)
    {
        List<Card> cards = new List<Card>();
        return cards;
    }
    public static List<Card> Level2UpgradeCards(CardEng cardEng, master master)
    {
        List<Card> cards = new List<Card>();
        return cards;
    }
    public static List<Card> Level3LockCards(CardEng cardEng, master master)
    {
        List<Card> cards = new List<Card>();
        return cards;
    }
    public static List<Card> Level3ShopCards(CardEng cardEng, master master)
    {
        List<Card> cards = new List<Card>();
        return cards;
    }
    public static List<Card> Level3UpgradeCards(CardEng cardEng, master master)
    {
        List<Card> cards = new List<Card>();
        return cards;
    }
}
