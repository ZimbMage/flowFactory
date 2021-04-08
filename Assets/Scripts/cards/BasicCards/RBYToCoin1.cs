using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBYToCoin1 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    public RBYToCoin1(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(2,2,2,0);
        CardOutput = new Transaction(0,0,0,4);
        cardName = "RBYToCoin1";
        mySprite = CheckForMissingArt(basicFactoryPath + cardName);
        CanUpgrade = true;
    }
    public override Card UpgradeCard()
    {
        return new RBYToCoin2(cardEng, Master);
    }
}
