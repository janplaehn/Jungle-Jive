using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//template class which takes two values of different classes and stores them
public class Pair<T, U>{
    public T firstValue;
    public U secondValue;
    public Pair(T givenFirstValue, U givenSecondValue)
    {
        if (givenFirstValue == null || givenSecondValue == null) Debug.LogError("Pair not initialized properly");
        firstValue = givenFirstValue;
        secondValue = givenSecondValue;
    }
    //can't access default constructor from the outside
    private Pair() { }
}