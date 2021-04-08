using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.EventSystems;

public class CardZone : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    public PlayerDeck playerDeck;
    public PlayerDiscard playerDiscard;
    public Card card { get; set; }
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        SetEmpty();
    }

    public void SetEmpty() 
    {
        card = new PlaceHolderCard();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = card.mySprite;
    }



    //request a card if i dont have a card

   public void GetCard()
    {
        if (card.cardName == "No Card")
        {
            card = playerDeck.DrawCardFromDeck();
            card.cardZone = this;
            card.OnDrawl();
            SetCardSprite();
            print(" i drew : " + card.cardName);
            //set sprite
            
        }                   
    }

    public void DiscardCard()
    {
        print("Start discard");
        
        if (card.cardName != "No Card")
        {
            playerDiscard.Cards.Add(card);
            card.OnDiscard();
            card = new PlaceHolderCard();
            SetCardSprite();
        }
        print("end discard");
        playerDiscard.SetDiscardCountUI();
    }

    public void TrashCard()
    {
        if (card.cardName != "No Card") 
        {
            card.UiTrash(Zones.master);
            card = new PlaceHolderCard();
            SetCardSprite();
        }
    }


    public void SetCardSprite() 
    {
        spriteRenderer.sprite = card.mySprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print("I got clicked");
        print("I have :" + card.cardName);
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // try to do card thing.
            if (card.Play())
            {
                card.CleanUp();
            }
            else
            {
                // failed to play the card. do card hint
                print("cant play card " + card.cardName);
            }
        }

    }
}
