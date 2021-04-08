using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowToBlue2 : Card
{
    public override string cardName { get; }
    public override bool CanUpgrade { get; }


    public YellowToBlue2(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(0, 0, 1, 0);
        CardOutput = new Transaction(0, 2, 0, 0);
        cardName = "YellowToBlue2";
        mySprite = Resources.Load<Sprite>(LevelOneFactoryPath + cardName);
        CanUpgrade = false;
    }
    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }
}
