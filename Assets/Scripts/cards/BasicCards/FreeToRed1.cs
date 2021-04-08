using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeToRed1 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    
    public FreeToRed1(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction();
        CardOutput = new Transaction(1,0,0,0);
        cardName = "FreeToRed1";       
        mySprite = CheckForMissingArt(basicFactoryPath + cardName);
        CanUpgrade = true;
    }

    public override Card UpgradeCard()
    {
        return new FreeToRed2(cardEng, Master);
    }
}
