using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueToYellow4 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    public BlueToYellow4(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(0, 4, 0, 0);
        CardOutput = new Transaction(0, 0, 7, 0);
        cardName = "BlueToYellow4";
        mySprite = CheckForMissingArt(LevelOneFactoryPath + cardName);
    }
    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }
}
