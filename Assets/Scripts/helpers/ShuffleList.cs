using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
public static class ShuffleList 
{
    public static void Shuffle<T>(List<T> Cards)
    {
        int n = Cards.Count;
        while (n > 1)
        {
            n--;
            int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
            T value = Cards[k];
            Cards[k] = Cards[n];
            Cards[n] = value;
        }

    }


}

public static class ThreadSafeRandom
{
    [ThreadStatic] private static System.Random Local;

    public static System.Random ThisThreadsRandom
    {
        get { return Local ?? (Local = new System.Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
    }
}