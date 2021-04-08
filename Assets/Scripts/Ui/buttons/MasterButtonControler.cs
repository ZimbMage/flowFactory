using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MasterButtonControler : MonoBehaviour, IPointerClickHandler
{

    public master gameMaster;
    public ButtonEffect effect;

    public void OnPointerClick(PointerEventData eventData)
    {
        print(effect);
        switch (effect)
        {
            case ButtonEffect.endTurn:
                gameMaster.EndTurn();
                break;
            case ButtonEffect.discrdFactory:
                gameMaster.DiscardFactorys();
                break;
            case ButtonEffect.deck:
                gameMaster.OpenDeckUI();
                break;
            case ButtonEffect.discardPile:
                gameMaster.OpenDiscardUI();
                break;
            case ButtonEffect.masterDeck:
                gameMaster.OpenMasterDeckUI();
                break;
            case ButtonEffect.startingDeck:
                gameMaster.OpenStartingeckUI();
                break;
            case ButtonEffect.exitShop:
                gameMaster.ExitShop();
                break;
        }
    }

 
}


public enum ButtonEffect
{
    endTurn,
    discrdFactory,
    deck,
    discardPile,
    masterDeck,
    startingDeck,
    exitShop
    
}