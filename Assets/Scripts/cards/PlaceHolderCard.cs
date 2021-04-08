using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class PlaceHolderCard : Card
{
    public override string cardName { get; }
    public  int cake = 0;
    public override bool CanUpgrade { get; }

    public PlaceHolderCard() 
    {
        cardName = "No Card";
        mySprite = Resources.Load<Sprite>("Sprites/Factorys/Placeholder");


    }

    public override bool Play()
    {
        return false;
    }

    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }
}
