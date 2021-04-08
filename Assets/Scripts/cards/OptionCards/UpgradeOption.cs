using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeOption : Card
{
    public override string cardName { get; }
    public override bool CanUpgrade { get; }



    public UpgradeOption(CardEng eng, master m1) : base(eng, m1)
    { 
        cardName = "Upgrade";
        mySprite = Resources.Load<Sprite>(optionPath + cardName);
    }


    public override void Option()
    {
        Master.OpenUpgradeUI(Zones.master);        
    }
    public override bool Play()
    {
        throw new System.NotImplementedException();
    }

    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }
}
