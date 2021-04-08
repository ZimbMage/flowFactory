using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeToBlue1 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    public FreeToBlue1(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction();
        CardOutput = new Transaction(0, 1, 0, 0);
        cardName = "FreeBlue1";
        mySprite = CheckForMissingArt(LevelOneFactoryPath + cardName);
        CanUpgrade = true;
    }



    public override Card UpgradeCard()
    {
        return new FreeToBlue2(cardEng, Master);
    }
}
