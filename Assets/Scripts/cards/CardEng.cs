using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEng 
{
   public Bank ActiveBank;
   public Bank NextBank;
   public BankUi ui;

    public CardEng(Bank Active,Bank Next,BankUi Ui)
    {
        ActiveBank = Active;
        NextBank = Next;
        ui = Ui;
        Debug.Log("starting Card Eng");
    }

    public bool PlayCard(Card card) 
    {
        bool CardPlayed =false;                             
        if (ActiveBank.CheckTransaction(Currency.red, card.CardCost.Red*-1)&&
            ActiveBank.CheckTransaction(Currency.blue, card.CardCost.Blue * -1)&& 
            ActiveBank.CheckTransaction(Currency.yellow, card.CardCost.Yellow * -1)&&
            ActiveBank.CheckTransaction(Currency.coin, card.CardCost.Coin * -1))
        {
            CardPlayed = true;
            PayCost(card);
            Payment(card);
        }
        if (CardPlayed)
        {
            card.PlayEffect();
            ui.UpdateUI();
        } 
        return CardPlayed;
    }


    void PayCost(Card card)
    {
        ActiveBank.Transaction(Currency.red, card.CardCost.Red*-1);
        ActiveBank.Transaction(Currency.blue, card.CardCost.Blue * -1);
        ActiveBank.Transaction(Currency.yellow, card.CardCost.Yellow * -1);
        ActiveBank.Transaction(Currency.coin, card.CardCost.Coin * -1);
    }

    void Payment(Card card) 
    {
        NextBank.Transaction(Currency.red, card.CardOutput.Red);
        NextBank.Transaction(Currency.blue, card.CardOutput.Blue);
        NextBank.Transaction(Currency.yellow, card.CardOutput.Yellow);
        ActiveBank.Transaction(Currency.coin, card.CardOutput.Coin);
    }

    public void HealthCheck() 
    {
        Debug.Log("Card Eng Health Check");    
    }
}