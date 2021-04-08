using System.Collections;
using System.Collections.Generic;

public class helper 
{

    public static string placeholderSprite = "Sprites/Factorys/NYI";

}

public enum Currency
{ 
    red,
    blue,
    yellow,
    coin

}

public enum ClickEffect
{

    option,
    trash,
    upgrade,
    newFactory,
    unlock,
    resorce,
    shop,
    nothing
}


//watch out for shop enum level, list loader uses it for some ui thing
public enum Zones
{
    deck,
    discard,
    deckAndDiscard,
    play,
    master,
    startingDeck,
    offerpool,
    shop1,
    shop2,
    shop3,
    lock1,
    lock2,
    lock3


}

public enum CardColor
{
    red,
    blue,
    yellow,
    redBlue,
    redYellow,
    blueYellow,
    tri,
    colorless
}