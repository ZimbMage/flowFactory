using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowResource : Card
{
    public override string cardName { get; }
    public override bool CanUpgrade { get; }

    public YellowResource(CardEng eng, master m1) : base(eng, m1)
    {
        cardName = "Yellow";
        mySprite = Resources.Load<Sprite>(optionPath + cardName);
        CanUpgrade = false;
        FactoryCost = m1.yellowCost1;
        myCurrency = Currency.yellow;
    }
    public override void PlayEffect()
    {
        Master.NextBank.Transaction(myCurrency, 1);
        Master.yellowCost1++;
    }
    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }

}
