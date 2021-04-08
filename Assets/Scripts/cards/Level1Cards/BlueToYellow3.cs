using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueToYellow3 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    public BlueToYellow3(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(0, 3, 0, 0);
        CardOutput = new Transaction(0, 0, 5, 0);
        cardName = "BlueToYellow3";
        mySprite = CheckForMissingArt(LevelOneFactoryPath+cardName);
        CanUpgrade = true;
    }

    public override Card UpgradeCard()
    {
        return new BlueToYellow4(cardEng, Master);
    }
}
