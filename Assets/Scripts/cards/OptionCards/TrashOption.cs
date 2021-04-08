using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashOption : Card
{
    public override string cardName { get; }
    public override bool CanUpgrade { get; }


    public TrashOption(CardEng eng, master m1) : base(eng, m1)
    {
        cardName = "Trash";
        mySprite = Resources.Load<Sprite>(optionPath + cardName);        
    }


    public override void  Option()
    {
        Debug.Log("option");
        // do the trash thing
        Master.OpenTrashUI(Zones.master);
        //open ui with master list
        
        // click to trash item.
        //trash the items
        //close the ui, and the other ui. 
    }

    public override Card UpgradeCard()
    {
        throw new System.NotImplementedException();
    }
}
