using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueResource : Card
{
    public override string cardName { get; }
    public override bool CanUpgrade { get; }
    public Currency currencyType;
    public BlueResource(CardEng eng, master m1) : base(eng, m1)
    {
        cardName = "Blue";
        mySprite = Resources.Load<Sprite>(optionPath + cardName);
        CanUpgrade = true;
        FactoryCost = m1.blueCost1;
        myCurrency = Currency.blue;
    }

    public override void PlayEffect()
    {
        Master.NextBank.Transaction(myCurrency, 1);
        Master.blueCost1++;
    }


    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }

}
