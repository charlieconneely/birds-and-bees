using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Abstract bird interface. Defines act method which all states must implement.
* This feature makes calling each state easier as they have persistent method name (Act)
*/
public abstract class BirdState
{
    protected Bird bird;

    public Bird Bird 
    {
        get { return bird; }
        set { bird = value; }
    }

    public abstract void Act();
}
