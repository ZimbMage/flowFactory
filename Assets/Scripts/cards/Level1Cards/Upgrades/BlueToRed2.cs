using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class BlueToRed2 : Card
{
    public override string cardName { get; }
    public override bool CanUpgrade { get; }

    public BlueToRed2(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(0,2,0,0);
        CardCost = new Transaction(3,0,0,0);
        cardName = "BlueToRed2";
        mySprite = Resources.Load<Sprite>(LevelOneFactoryPath + cardName);
    }


    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }
}
