using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBToCoin2 : Card
{
    public override string cardName { get; }
    //costs
    private readonly int RedCost = -2;
    private readonly int BlueCost = -2;
    //payment
    public readonly int CoinPayment = 2;
    public override bool CanUpgrade { get; }

    public RBToCoin2(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(2, 2, 0, 0);
        CardOutput = new Transaction(0, 0, 0, 2);
        cardName = "RBToCoin2";
        mySprite = Resources.Load<Sprite>(LevelOneFactoryPath + cardName);
        CanUpgrade = false;
    }


    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }
}
