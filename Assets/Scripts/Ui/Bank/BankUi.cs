using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BankUi : MonoBehaviour
{

    public Bank thisTurnBank;
    public Bank nextTurnBank;
    public Bank coinBank;
    public TMP_Text thisTurnBankText;
    public TMP_Text nextTurnBankText;
    public TMP_Text coinText;

    public void UpdateUI()     
    {
        SetNextTurnText();
        SetThisTurnText();
        SetCoinText();
    }



    public void SetThisTurnText() 
    {
        thisTurnBankText.text = string.Format("R:{0} B:{1} Y:{2} " , thisTurnBank.Red,thisTurnBank.Blue,thisTurnBank.Yellow);
    }

    public void SetNextTurnText() 
    {         
        nextTurnBankText.text = string.Format("R:{0} B:{1}  Y:{2}", nextTurnBank.Red, nextTurnBank.Blue, nextTurnBank.Yellow);        
    }

    public void SetCoinText() 
    {
        coinText.text = string.Format("Coins: {0}", coinBank.Coin);
    }

   public void dump()
    {
        Debug.Log("ActiveBank: " +thisTurnBank.GetBankSum());
        Debug.Log("NextBank: " + nextTurnBank.GetBankSum());

    }

}
