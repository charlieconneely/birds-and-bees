using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Dancing state
*/
public class Dancing : BeeState
{
    private GameObject hive;
    private float fullNectar = 10f;
    private float speed;
    private float offLoadRate = 0.2f;
    private Color color = Color.cyan;
    private float energy;
    private float energyIncrease = 0.6f;
    private bool finishedUnloading = false;

    public Dancing(Bee bee)
    {
        this.bee = bee;
    }

    public override void Act() 
    {
        Dance();
    }

    private void Dance() 
    {
        bee.GetComponent<SpriteRenderer>().color = color; 
        hive = bee.getHive();
        speed = bee.getSpeed();

        float step = speed * Time.deltaTime;
        bee.transform.position = Vector2.MoveTowards(bee.transform.position, hive.transform.position, step);

        if (bee.transform.position.x == hive.transform.position.x &&
        bee.transform.position.y == hive.transform.position.y) {
            if (!finishedUnloading) {
                Unload();
            } else {
                StartResting();
            }
        }
    }

    private void Unload()
    {
        fullNectar -= offLoadRate;
        if (fullNectar <= 0f) {
            finishedUnloading = true;
            // reset nectar for next time
            fullNectar = 10f;
        }
    }

    private void StartResting()
    {
        energy = bee.getEnergy();
        if (energy < 3) {
            energy += energyIncrease * Time.deltaTime;
            bee.setEnergy(energy);
        } else {
            finishedUnloading = false;
            bee.setState(bee.getSearchingState());
        }
    }
}
