using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData 
{
    public List<string> masterDeck = new List<string>();
    public List<string> myDeck = new List<string>();
    public List<string> startingDeck = new List<string>();
    public List<string> offerPool = new List<string>();
    public List<string> cardShopT1 = new List<string>();
    public List<string> cardShopT2 = new List<string>();
    public List<string> cardShopT3 = new List<string>();
    public List<string> cardLockedT1 = new List<string>();
    public List<string> cardLockedT2 = new List<string>();
    public List<string> cardLockedT3 = new List<string>();
    public Bank curentBank = new Bank();
    public Bank startingBank = new Bank();
    public int curentTurn = 0;
    public int coins = 0;
    public int score = 0;
    public int level = 0;
    public int gameCount = 0;
    public int redCost1 = 0;
    public int blueCost1 = 0;
    public int yellowCost1 = 0;
    public int coinCost1 = 0;
    public GameScreen gameScreen = GameScreen.MainMenu;
}
