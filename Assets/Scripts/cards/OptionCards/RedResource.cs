using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedResource : Card
{
    public override string cardName { get; }
    public override bool CanUpgrade { get; }

    public RedResource(CardEng eng, master m1) : base(eng, m1)
    { 
        cardName = "Red";
        mySprite = Resources.Load<Sprite>(optionPath + cardName);
        CanUpgrade = false;
        FactoryCost = m1.redCost1;
        myCurrency = Currency.red;
    }


    public override void PlayEffect()
    {
        Master.NextBank.Transaction(myCurrency, 1);
        Master.redCost1++;
    }

    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }


}
