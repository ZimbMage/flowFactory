using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeToBlue2 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    public FreeToBlue2(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction();
        CardOutput = new Transaction(0,2,0,0);
        cardName = "FreeBlue2";
        mySprite = CheckForMissingArt(LevelOneFactoryPath + cardName);
    }
    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }
}
