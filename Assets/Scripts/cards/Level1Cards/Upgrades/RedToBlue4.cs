using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedToBlue4 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    public RedToBlue4(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(4, 0, 0, 0);
        CardOutput = new Transaction(0, 7, 0, 0);
        cardName = "RedToBlue4";
        mySprite = CheckForMissingArt(LevelOneFactoryPath + cardName);
    }

    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }
}
