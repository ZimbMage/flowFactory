using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transaction 
{

    public int Red;
    public int Blue;
    public int Yellow;
    public int Coin;

    public Transaction()
    {
        Red = 0;
        Blue = 0;
        Yellow = 0;
        Coin = 0;
    }
    public Transaction(int red, int blue,int yellow,int coin) 
    {
        Red = red;
        Blue = blue;
        Yellow = yellow;
        Coin = coin;
    }
    public void debug() 
    {
        Debug.Log("Red" + Red);
        Debug.Log("Blue" + Blue);
        Debug.Log("Yellow" + Yellow);
        Debug.Log("Coin" + Coin);
    }
}
