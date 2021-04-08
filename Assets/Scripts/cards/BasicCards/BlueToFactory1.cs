using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueToFactory1 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    private Zones targetZone = Zones.discard;
    public BlueToFactory1(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(0,1,0,0);
        CardOutput = new Transaction();
        cardName = "BlueToFactory1";
        mySprite = CheckForMissingArt(basicFactoryPath + cardName);
        CanUpgrade = true;
    }


    public override void PlayEffect() 
    {
        Master.OfferCard(targetZone);
    }


    public override void CleanUp() 
    {
        Debug.Log(cardName + " Discarding! OverRide");
        cardZone.DiscardCard();
        cardZone.GetCard();

    }

    public override Card UpgradeCard()
    {
        return new BlueToFactory2(cardEng, Master);
    }
}
