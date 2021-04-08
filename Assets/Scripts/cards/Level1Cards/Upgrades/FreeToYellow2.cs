using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeToYellow2 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    public FreeToYellow2(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction();
        CardOutput = new Transaction(0, 0, 2, 0);
        cardName = "FreeYellow2";
        mySprite = CheckForMissingArt(LevelOneFactoryPath + cardName);
    }


    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }
}
