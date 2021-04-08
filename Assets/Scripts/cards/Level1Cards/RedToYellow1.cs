using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedToYellow1 : Card
{
    public override string cardName { get; }
    //costs
    private readonly int RedCost = -2;
    //payment
    public readonly int YellowPayment = 1;
    public override bool CanUpgrade { get; }


    public RedToYellow1(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(2, 0, 0, 0);
        CardOutput = new Transaction(0, 0, 1, 0);
        cardName = "RedToYellow1";
        mySprite = Resources.Load<Sprite>(LevelOneFactoryPath + cardName);
        CanUpgrade = true;
    }

    public override Card UpgradeCard()
    {
        return new RedToYellow2(cardEng, Master);
    }

}
