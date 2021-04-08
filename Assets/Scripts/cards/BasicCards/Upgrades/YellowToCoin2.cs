using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowToCoin2 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    public YellowToCoin2(CardEng eng, master m1) : base(eng, m1)
    {
        cardName = "YellowToCoin2";
        CardCost = new Transaction(0, 0, 2, 0);
        CardOutput = new Transaction(0, 0, 0, 2);
        mySprite = CheckForMissingArt(basicFactoryPath + cardName);
    }



    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }
}