using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowToUpgrade2 : Card
{
    public override bool CanUpgrade { get; }
    public override string cardName { get; }
    private Zones targetZone = Zones.deckAndDiscard;
    public YellowToUpgrade2(CardEng eng, master m1) : base(eng, m1)
    {
        CardCost = new Transaction(0, 0, 1, 0);
        cardName = "YellowToUpgrade2";
        mySprite = CheckForMissingArt(basicFactoryPath + cardName);
    }
    public override void PlayEffect()
    {
        Master.OpenUpgradeUI(targetZone);
    }
    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }
}
