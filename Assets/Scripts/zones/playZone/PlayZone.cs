using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayZone : MonoBehaviour
{

    public GameObject Deck;
    public GameObject Discard;
    public List<CardZone> cardZones;





    public void HaveCardZonesGetCards()
    {
        foreach  (CardZone zone in cardZones)
        {
            zone.GetCard();        
        }
    }

    public void HaveCardZonesDisardCards()
    {


        foreach (CardZone zone in cardZones)
        {
            zone.DiscardCard();
        }

    }

    public void CleanUpCardSlots()
    {

        foreach (CardZone zone in cardZones)
        {
            zone.SetEmpty();
        }



    }







}
