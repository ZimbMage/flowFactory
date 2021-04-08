using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class ListItemController :  MonoBehaviour, IPointerClickHandler
{

   public Image icon;
   public Card myCard;
   public ClickEffect clickEffect;
   public Zones zone;
   public TMP_Text UiText;
   public bool free;
   public bool preview = false;
   public Bank theBank;


    public void OnPointerClick(PointerEventData eventData)
    {
         
        print(myCard.cardName);
        print(clickEffect);
        switch (clickEffect) { 
            case ClickEffect.nothing:
                if (eventData.button == PointerEventData.InputButton.Right)
                {
                    UpgradePreview();
                }
                break;
            case ClickEffect.option:
                if (eventData.button == PointerEventData.InputButton.Left)
                {
                    myCard.Option();
                }
                break;
            case ClickEffect.trash:
                if (eventData.button == PointerEventData.InputButton.Left)
                {
                    myCard.UiTrash(zone);
                }
                if (eventData.button == PointerEventData.InputButton.Right)
                {
                    UpgradePreview();
                }
                break;
            case ClickEffect.upgrade:
                if (eventData.button == PointerEventData.InputButton.Left)
                {
                    myCard.UiUpgrade(zone);
                }
                if(eventData.button== PointerEventData.InputButton.Right) 
                {
                    UpgradePreview();
                }
                break;
            case ClickEffect.unlock:
                if (eventData.button == PointerEventData.InputButton.Left)
                {
                    myCard.Unlock(zone);
                    
                }
                if (eventData.button == PointerEventData.InputButton.Right)
                {
                    UpgradePreview();
                }
                break;
            case ClickEffect.newFactory:
                if (eventData.button == PointerEventData.InputButton.Left)
                {
                        if (UiText != null)
                        {
                            UiText.text = "Sold";
                        }
                        this.gameObject.SetActive(false);
                        myCard.Add(zone);

                }
                if (eventData.button == PointerEventData.InputButton.Right)
                {
                    UpgradePreview();
                }
                break;
            case ClickEffect.resorce:
                if (myCard.Master.CurrentBank.Transaction(Currency.coin,myCard.FactoryCost*-1))
                {
                    UiText.text = "Sold";
                    this.gameObject.SetActive(false);
                    myCard.PlayEffect();
                    myCard.Master.bankUi.UpdateUI();

                }
                break;
            case ClickEffect.shop:
                if (myCard.Master.CurrentBank.Transaction(Currency.coin, myCard.FactoryCost * -1))
                {
                    UiText.text = "Sold";
                    this.gameObject.SetActive(false);                    
                    myCard.Add(zone);
                    myCard.Master.bankUi.UpdateUI();
                }
                break;
        }        
    }


    public void UpgradePreview() 
    {
        if (preview == false && myCard.CanUpgrade)
        {
            icon.sprite = myCard.UpgradeCard().mySprite;
            preview = true;
        }
        else if(preview && myCard.CanUpgrade)
        {
            icon.sprite = myCard.mySprite;
            preview = false;
        }
    }

   

}


