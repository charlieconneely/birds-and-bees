using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Abstract bee interface. Defines act method which all states must implement.
* This feature makes calling each state easier as they have persistent method name (Act)
*/
public abstract class BeeState
{
    protected Bee bee;

    public Bee Bee 
    {
        get { return bee; }
        set { bee = value; }
    }

    public abstract void Act();
}
