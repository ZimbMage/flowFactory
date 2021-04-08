using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedToBlue3 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    public RedToBlue3(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(3, 0, 0, 0);
        CardOutput = new Transaction(0, 5, 0, 0);
        cardName = "RedToBlue3";
        mySprite = CheckForMissingArt(LevelOneFactoryPath + cardName);
        CanUpgrade=true;
    }



    public override Card UpgradeCard()
    {
        return new RedToBlue4(cardEng, Master);
    }
}
