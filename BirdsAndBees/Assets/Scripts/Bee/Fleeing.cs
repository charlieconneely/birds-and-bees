using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
* Fleeing state
*/
public class Fleeing : BeeState
{
    public Fleeing(Bee bee)
    {
        this.bee = bee;
    }

    public override void Act()
    {
        Flee();
    }

    public void Flee()
    {
        Debug.Log("Fleeing");
    }
}
