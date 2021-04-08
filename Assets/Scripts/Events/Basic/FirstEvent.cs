using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEvent : Event
{
    // no constuctors.

    string Title = "First Event";
    string Body = "Please Chose An Option Below";
    List<string> Choices = new List<string> 
    { 
    "Red","Blue","Yellow","Coin"
    };

}
