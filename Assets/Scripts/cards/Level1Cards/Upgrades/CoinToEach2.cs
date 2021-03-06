using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinToEach2 : Card
{
    public override string cardName { get; }
    public override bool CanUpgrade { get; }


    public CoinToEach2(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(0,0,0,1);
        CardOutput = new Transaction(2, 1, 1, 0);
        cardName = "CoinToEach2";
        mySprite = Resources.Load<Sprite>(LevelOneFactoryPath + cardName);
        CanUpgrade = false;
    }


    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }
}
