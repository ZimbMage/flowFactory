using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
[Serializable]
public class RedToBlueFactory1 : Card
    {
    public override string  cardName { get; }
    public override bool CanUpgrade { get; }

    //costs


    public RedToBlueFactory1(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(1,0,0,0);
        CardOutput = new Transaction(0,2,0,0);
        cardName = "redToBlue1";
        mySprite = CheckForMissingArt(basicFactoryPath+cardName);
        CanUpgrade = true;
    }



    public override Card UpgradeCard()
    {
        return new RedToBlue2(cardEng,Master);
    }

  
}
