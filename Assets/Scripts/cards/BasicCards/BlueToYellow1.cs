using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueToYellow1 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    public BlueToYellow1(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(0,1,0,0);
        CardOutput = new Transaction(0,0,2,0);
        cardName = "BlueToYellow1";
        Master = m1;
        mySprite = CheckForMissingArt(basicFactoryPath + cardName);
        CanUpgrade = true;
    }

    public override Card UpgradeCard()
    {
        return new BlueToYellow2(cardEng,Master);
    }
}
