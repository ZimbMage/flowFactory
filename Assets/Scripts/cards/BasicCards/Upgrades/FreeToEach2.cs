using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeToEach2 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }

    public FreeToEach2(CardEng eng, master m1) : base(eng, m1)
    {
        CardOutput = new Transaction(1,1,1,1);
        cardName = "FreeToEach2";
        Master = m1;
        mySprite = CheckForMissingArt(basicFactoryPath + cardName);
    }


    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }
}
