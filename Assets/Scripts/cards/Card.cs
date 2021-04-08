using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
[Serializable]
public abstract class Card 
{
   public master Master;
   public CardZone cardZone;
   public  Sprite mySprite;
   public Currency myCurrency;
   protected string basicFactoryPath = "Sprites/Factorys/BasicFactorys/";
   protected string LevelOneFactoryPath = "Sprites/Factorys/LevelOne/";
   protected string optionPath = "Sprites/Options/";
   public abstract bool CanUpgrade { get; }
   public abstract string cardName { get; }
   public int FactoryCost = 3;
   public CardEng cardEng;
   public Transaction CardCost;
   public Transaction CardOutput;
  
    public Card(CardEng eng, master master) 
    {
       
       
        cardEng = eng;
        Master = master;
    }

    protected Card()
    {
    }

    //        throw new System.NotImplementedException();
    public virtual void OnDrawl()
    { 
    }
    public virtual bool Play()
    {
        return cardEng.PlayCard(this);
    }

    public virtual void PlayEffect() {}
    public virtual void OnDiscard()
    {
    }
    //ui and eng logic
    public virtual void UiTrash(Zones zone)
    {
        Debug.Log("Trash card: " + cardName + "at zone: " + zone);
        Debug.Log(Master.turn);
        Master.RemoveCard(zone, this);
        Master.CloseAllUI();
        OnTrash();

    }
    //ui and eng logic
    public virtual void UiUpgrade(Zones zone)
    {
        Debug.Log("Upgrade card: " + cardName + "at zone: " + zone);
        //remove the card
        Master.RemoveCard(zone, this);
        //add the card
        Master.AddCard(zone, UpgradeCard());
        Master.CloseAllUI();
       //add the upgrade

    }
    //game logic
    public virtual void OnTrash()
    {
     

    }
    //ui and eng logic
    public virtual void Option()
    { 
    }
    // unlock is going events any cost will be the event system problem. 
    public virtual bool Unlock(Zones zone) 
    {
            Master.UnlockCard(zone,this);
            return true;
    }
    // how do we shop now with no bank ref? need a real shop class imo. 
    public virtual void Add(Zones zone)
    {
            Master.AddCard(zone,this);
    }
    // return a copy of the card
    public Card ReturnSelf() 
    {
        return this;
    }
    public abstract Card UpgradeCard();
    public Sprite CheckForMissingArt(string mySpritePath) 
    {
        Sprite sprite  = Resources.Load<Sprite>(mySpritePath);
        if (sprite is null)
        {
            Debug.LogError("missing sprite for " + basicFactoryPath + cardName);
            return Resources.Load<Sprite>(helper.placeholderSprite);
        }
        return sprite;            
    }

    public virtual void CleanUp() 
    {
        Debug.Log(cardName + " Discarding!");
        cardZone.DiscardCard();
        cardZone.GetCard();
    }

}
