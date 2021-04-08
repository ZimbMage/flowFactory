using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueToYellow2 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    public BlueToYellow2(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(0,1,0,0);
        CardCost = new Transaction(0,0,3,0);
        cardName = "BlueToYellow2";        
        mySprite = CheckForMissingArt(basicFactoryPath + cardName);
    }



    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }
}
