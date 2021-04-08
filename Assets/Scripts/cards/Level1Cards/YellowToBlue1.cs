using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowToBlue1 : Card
{
    public override string cardName { get; }
    public override bool CanUpgrade { get; }


    public YellowToBlue1(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(0, 0, 1, 0);
        CardOutput = new Transaction(0, 1, 0, 0);
        cardName = "YellowToBlue1";
        mySprite = Resources.Load<Sprite>(LevelOneFactoryPath + cardName);
        CanUpgrade = true;
    }



    public override Card UpgradeCard()
    {
        return new YellowToBlue2(cardEng, Master);
    }
}
