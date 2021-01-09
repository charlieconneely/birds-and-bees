using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* Initial state
*/
public class AtHive : BeeState
{
    public AtHive(Bee bee)
    {
        this.bee = bee;
    }

    public override void Act()
    {
        StartSearching();
    }    

    public void StartSearching()
    {
        bee.setState(bee.getSearchingState());
    }
}
