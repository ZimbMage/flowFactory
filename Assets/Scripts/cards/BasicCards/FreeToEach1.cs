using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeToEach1 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    public FreeToEach1(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction();
        CardOutput = new Transaction(1, 1, 1, 0);
        cardName = "FreeToEach1";
        Master = m1;
        mySprite = CheckForMissingArt(basicFactoryPath + cardName);
        CanUpgrade = true;
    }



    public override Card UpgradeCard()
    {
        return new FreeToEach2(cardEng,Master);
    }
}
