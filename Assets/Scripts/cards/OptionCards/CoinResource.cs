using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinResource : Card
{
    public override string cardName { get; }
    public override bool CanUpgrade { get; }
    public CoinResource(CardEng eng, master m1) : base(eng, m1)
    {        
        cardName = "Coin";
        mySprite = Resources.Load<Sprite>(optionPath + cardName);
        CanUpgrade = false;
        FactoryCost = m1.coinCost1;
        myCurrency = Currency.coin;
    }

    public override void PlayEffect()
    {
        Master.NextBank.Transaction(myCurrency, 1);
        Master.coinCost1++;
    }

    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }

}
