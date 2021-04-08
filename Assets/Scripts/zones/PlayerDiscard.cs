using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDiscard : MonoBehaviour
{


    public List<Card> Cards;
    public TMP_Text discardCount;

    private void Awake()
    {
        DiscardSetup();
    }


    public void SetDiscardCountUI()
    {
        discardCount.text = string.Format("{0}", Cards.Count);
    }

    public void DiscardSetup()
    {
        Cards = new List<Card>();
        SetDiscardCountUI();
    }

}
