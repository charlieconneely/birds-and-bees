using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
* Searching state
*/
public class Searching : BeeState
{
    private List<GameObject> flowers;
    private Vector2 currentPos;
    private Vector2 nextPos;
    private int count = 0;
    private Color fitColor = Color.green;
    private Color tiredColor = Color.yellow;
    private Color tooTiredColor = Color.red;
    private float speed;
    private float energy;
    private float energyLoss = 0.1f;

    public Searching(Bee bee) 
    {
        this.bee = bee;
    }

    public override void Act()
    {
        Search();
    }

    private void Search() 
    {
        checkEnergy();
        flowers = bee.getFlowers();        
        speed = bee.getSpeed();


        float step = speed * Time.deltaTime;
        bee.transform.position = Vector2.MoveTowards(bee.transform.position, flowers[count].transform.position, step);
        if (bee.transform.position.x == flowers[count].transform.position.x &&
        bee.transform.position.y == flowers[count].transform.position.y) {
            bee.setState(bee.getGatherState());
            if (count < 3) {
                count++;
            } else {
                count = 0;
            }
        }
    }

    private void checkEnergy()
    {
        energy = bee.getEnergy();
        if (energy > 2f) {
            bee.GetComponent<SpriteRenderer>().color = fitColor; 
        } else if (energy > 1f) {
            bee.GetComponent<SpriteRenderer>().color = tiredColor; 
        } else {
            bee.GetComponent<SpriteRenderer>().color = tooTiredColor; 
        }

        /* if the energy is too low - get back to the hive */
        if (energy < 0.5f) bee.setState(bee.getDancingState());

        energy -= energyLoss * Time.deltaTime;
        bee.setEnergy(energy);
    }
}
