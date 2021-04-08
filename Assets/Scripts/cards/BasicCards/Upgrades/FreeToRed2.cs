using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeToRed2 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    public FreeToRed2(CardEng eng,master m1) : base(eng, m1)
    {
        cardName = "FreeRed2";        
        mySprite = CheckForMissingArt(basicFactoryPath + cardName);
        CardOutput = new Transaction(2,0,0,0);
    }


    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }
}
