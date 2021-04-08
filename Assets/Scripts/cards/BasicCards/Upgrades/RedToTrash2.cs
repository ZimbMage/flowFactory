using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedToTrash2 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    private Zones targetZone = Zones.deckAndDiscard;
    public RedToTrash2(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(1,0,0,0);
        cardName = "RedToTrash2";
        mySprite = CheckForMissingArt(basicFactoryPath + cardName);
    }


    public override void PlayEffect()
    {
        Master.OpenTrashUI(targetZone);
    }


    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }
}
