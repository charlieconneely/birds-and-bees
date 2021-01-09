using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
* Gathering state
*/
public class Gathering : BeeState
{
    private float nectarGathered = 0f;
    private float maxNectar = 10f;
    private float totalNectarGathered = 0f;
    private float limitPerFlower = 2f;
    private Color color = Color.blue;

    public Gathering(Bee bee)
    {
        this.bee = bee;
    }

    public override void Act()
    {
        Gather();
    }

    private void Gather()
    {
        bee.GetComponent<SpriteRenderer>().color = color; 
        nectarGathered += 1f * Time.deltaTime;

        //bee.checkNectar(nectarGathered);

        if (nectarGathered >= limitPerFlower) {
            //bee.checkNectar(nectarGathered);
            totalNectarGathered += nectarGathered;
            if (totalNectarGathered >= maxNectar) {
                nectarGathered = 0f;
                totalNectarGathered = 0f;
                bee.setState(bee.getDancingState());
            } else {
                nectarGathered = 0f;
                bee.setState(bee.getSearchingState());
            }
        }
    }
}
