using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Threading;

public class PlayerDeck : MonoBehaviour
{

    public List<Card> Cards;
    public TMP_Text deckCount;


    private void Awake()
    {

       Cards = new List<Card>();

}


    public void DeckSetup(List<Card> deck)
    {
        Cards = new List<Card>();
        Cards.AddRange(deck);
        ShuffleList.Shuffle<Card>(Cards);
        SetDeckCountUI();
    }
    //shuffle cards



    //draw cards

    public Card DrawCardFromDeck() 
    {
        //get a card from list and remove card
        if (IsDeckEmpty())
        {
            //deck is empaty
            return new PlaceHolderCard();
        }    
        Card card = Cards[0];
        Cards.RemoveAt(0);
        SetDeckCountUI();
        return card;        
    }   

    public bool IsDeckEmpty()
    {
        if (Cards.Count == 0)
            return true;


        return false;
    }


    public void SetDeckCountUI() 
    {        
        deckCount.text = string.Format("{0}", Cards.Count);    
    }



   


}
