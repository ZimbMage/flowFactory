using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ListController : MonoBehaviour
{
    public GameObject ControlPanel;
    public GameObject ListItemPrefab;
    public Canvas Canvas;
    public TMP_Text UiText;


    public void LoadList(List<Card> myCards, bool shuffle = true, ClickEffect clickEffect = ClickEffect.nothing, Zones zone = Zones.master, bool forSale = false, bool free= true, int cap =-99)
    {
        List<Card> copyOfmyCards = new List<Card>();
        int i = 0;
        copyOfmyCards.AddRange(myCards);
        if (shuffle)
        {
            ShuffleList.Shuffle<Card>(copyOfmyCards);
        }
        print(clickEffect);
        foreach (Card card in copyOfmyCards)
        {
            if (clickEffect == ClickEffect.upgrade && card.CanUpgrade == false) 
            {
                continue;
            } 
            GameObject newCard = Instantiate(ListItemPrefab) as GameObject;
            ListItemController controller = newCard.GetComponentInChildren<ListItemController>();            
            controller.myCard = card;
            
            controller.icon.sprite = card.mySprite;
            
            controller.clickEffect = clickEffect;
            controller.zone = zone;
            controller.free = free;

            if (forSale) 
            {
                    controller.UiText.text = "Cost: " + card.FactoryCost;
            }
            newCard.transform.SetParent(ControlPanel.transform, false);
            newCard.transform.localScale = Vector3.one;
            i++;
            if (i >= cap && cap > 0) 
            {
                break;
            }               
        }

        }





    public void DeleteList()
    {

        foreach (Transform child in ControlPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
            

    }

    public void CloseUI() 
    {

        DeleteList();
        Canvas.gameObject.SetActive(false);


    }
}
