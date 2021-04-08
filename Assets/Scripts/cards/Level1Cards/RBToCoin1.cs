using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBToCoin1 : Card
{
    public override string cardName { get; }
    public override bool CanUpgrade { get; }


    public RBToCoin1(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(1,1,0,0);
        CardOutput = new Transaction(0,0,0,1);
        cardName = "RBToCoin1";
        mySprite = Resources.Load<Sprite>(LevelOneFactoryPath + cardName);
        CanUpgrade = true;
    }


    public override Card UpgradeCard()
    {
        return new RBToCoin2(cardEng, Master);
    }
}
