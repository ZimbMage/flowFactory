using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RedToBlue2 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    public RedToBlue2(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(1,0,0,0);
        CardOutput = new Transaction(0,2,0,0);
        cardName = "redToBlue2";
        mySprite = Resources.Load<Sprite>(basicFactoryPath + cardName);
    }



    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }
}
