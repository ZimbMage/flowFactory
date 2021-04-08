using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeToYellow1 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    public FreeToYellow1(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction();
        CardOutput = new Transaction(0,0,1,0);
        cardName = "FreeYellow1";
        mySprite = CheckForMissingArt(LevelOneFactoryPath + cardName);
        CanUpgrade = true;
    }

    public override Card UpgradeCard()
    {
        return new FreeToYellow2(cardEng, Master);
    }
}
