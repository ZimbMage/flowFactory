using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowToUpgrade1 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    private Zones targetZone = Zones.deck;
    public YellowToUpgrade1(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(0,0,1,0);
        cardName = "YellowToUpgrade1";
        mySprite = CheckForMissingArt(basicFactoryPath + cardName);
        CanUpgrade = true;
    }


    public override void PlayEffect()
    {
        Master.OpenUpgradeUI(targetZone);
    }

    public override void CleanUp()
    {
        cardZone.DiscardCard();

    }

    public override Card UpgradeCard()
    {
        return new YellowToUpgrade2(cardEng, Master);
    }
}
