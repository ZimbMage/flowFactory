using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinToEach1 : Card
{
    public override string cardName { get; }
    public override bool CanUpgrade { get; }


    public CoinToEach1(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(0,0,0,1);
        CardOutput = new Transaction(1, 1, 1, 0);
        cardName = "CoinToEach1";
        mySprite = Resources.Load<Sprite>(LevelOneFactoryPath + cardName);
        CanUpgrade = true;
    }



    public override Card UpgradeCard()
    {
        return new CoinToEach2(cardEng,Master);
    }
}
