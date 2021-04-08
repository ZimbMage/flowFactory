using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedToTrash1 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    private Zones targetZone = Zones.discard;
    public RedToTrash1(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(1, 0, 0, 0);
        CardOutput = new Transaction();
        cardName = "RedToTrash1";
        mySprite = CheckForMissingArt(basicFactoryPath + cardName);
        CanUpgrade = true;
    }

    public override bool Play()
    {
            // make a call to list UI
            //you can skip but no take backs for this one so just discard the card. 
            Master.OpenTrashUI(targetZone);
            return true;

    }

    public override void CleanUp()
    {
        cardZone.DiscardCard();

    }
    public override Card UpgradeCard()
    {
        return new RedToTrash2(cardEng,Master);
    }
}
