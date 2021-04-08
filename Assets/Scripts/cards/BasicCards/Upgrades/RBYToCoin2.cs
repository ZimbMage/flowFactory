using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBYToCoin2 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }

    public RBYToCoin2(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(1,1,2,0);
        CardCost = new Transaction(0,0,0,4);
        cardName = "RBYToCoin2";
        Master = m1;
        mySprite = CheckForMissingArt(basicFactoryPath + cardName);
    }

    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }
}
