using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueToFactory2 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    private Zones targetZone = Zones.deck;
    public BlueToFactory2(CardEng eng, master m1) : base(eng, m1)
    {
        cardName = "BlueToFactory2";
        CardCost = new Transaction(0, 1, 0, 0);
        mySprite = CheckForMissingArt(basicFactoryPath + cardName);
        CanUpgrade = true;
    }
    public override void PlayEffect()
    {
        Master.OfferCard(targetZone);
    }
    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }
}
