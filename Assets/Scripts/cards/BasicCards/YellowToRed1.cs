using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowToRed1 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    public YellowToRed1(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(0,0,1,0);
        CardOutput = new Transaction(2,0,0,0);
        cardName = "YellowToRed1";
        mySprite = CheckForMissingArt(basicFactoryPath + cardName);
        CanUpgrade = true;
    }

    public override Card UpgradeCard()
    {
        return new YellowToRed2(cardEng, Master);
    }
}
