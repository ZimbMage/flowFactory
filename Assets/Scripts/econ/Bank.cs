using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Bank 
{
   public int Red = 0;
   public int Blue = 0;
   public int Yellow =0;
   public int Coin = 0;
    public string name;

    public bool Transaction(Currency currency, int ammount ) 
    {
        bool transaction = true;
        switch (currency)
        {
            case Currency.red:
                if (Red + ammount >= 0)
                {
                    Red += ammount;                   
                    break;
                }
                else 
                {
                    transaction= false;
                    break;
                }
            case Currency.blue:
                if (Blue + ammount >= 0)
                {
                    Blue += ammount;
                    break;
                }
                else
                {
                    transaction = false;
                    break;
                }
            case Currency.yellow:
                if (Yellow + ammount >= 0)
                {
                    Yellow += ammount;
                    break;
                }
                else
                {
                    transaction = false;
                    break;
                }
            case Currency.coin:
                if (Coin + ammount >= 0)
                {
                    Coin += ammount;
                    break;
                }
                else
                {
                    transaction = false;
                    break;

                }
        }
        return transaction;
    }

    public bool CheckTransaction(Currency currency, int ammount) 
    {
        switch (currency)
        {
            case Currency.red:
                if (Red + ammount < 0)
                {
                    return false;
                }
                break;
            case Currency.blue:
                if (Blue + ammount < 0)
                {
                    return false;
                }
                break;
            case Currency.yellow:
                if (Yellow + ammount < 0)
                {
                    return false;
                }
                break;
            case Currency.coin:
                if (Coin + ammount < 0)
                {
                    return false;
                }
                break;
        }
        return true;
    }

    public void TranferValues(Bank bank)
    {
        Red+=bank.Red;
        Blue+=bank.Blue;
        Yellow += bank.Yellow;
        Coin += bank.Coin;
    }

    public void ClearBank() 
    {
        Red = 0;
        Blue = 0;
        Yellow = 0;
        Coin = 0;
    }

    public int GetBankSum() 
    {
        return (Red + Blue + Yellow + Coin);
    }
}
