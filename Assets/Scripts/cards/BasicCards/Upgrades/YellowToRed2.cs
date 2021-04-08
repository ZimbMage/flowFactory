using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowToRed2 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    public YellowToRed2(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(0,0,1,0);
        CardOutput = new Transaction(3,0,0,0);
        cardName = "YellowToRed2";
        mySprite = CheckForMissingArt(basicFactoryPath + cardName);
    }

    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }
}
