using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class BlueToRed1 : Card
{
    public override string cardName { get; }
    public override bool CanUpgrade { get; }
    
  public  BlueToRed1(CardEng eng, master m1) : base(eng, m1)
    {
        cardName = "BlueToRed1";
        CardCost = new Transaction(0,1,0,0);
        CardOutput = new Transaction(1,0,0,0); 
        mySprite = Resources.Load<Sprite>(LevelOneFactoryPath + cardName);
        CanUpgrade = true;
    }
 
    public override Card UpgradeCard()
    {
        return new BlueToRed2(cardEng, Master);
    }
}
