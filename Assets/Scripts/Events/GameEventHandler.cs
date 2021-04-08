using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameEventHandler : MonoBehaviour
{
    public GameObject eventUi;
    public TMP_Text Title;
    public TMP_Text Body;
    public List<GameObject> Options = new List<GameObject>();
   // public GameObject CloseEvent;

    void Start()
    {
        Debug.Log("EventSystemStart");
    }

        public void LoadEvent(Event e)
        {
        eventUi.SetActive(true);
        Title.text = e.Title;
        Body.text = e.Body;

        for (int i=0; i < e.Choices.Count; i++) 
        {
            GameObject Button = Options[i];
            Button.SetActive(true);
            Button.GetComponentInChildren<Text>().text = e.Choices[i];

            
        }


        }


    public void choice(int value) 
    { 
    


    }




}
