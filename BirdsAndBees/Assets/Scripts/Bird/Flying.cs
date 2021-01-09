using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
* Fleeing state
*/
public class Flying : BirdState
{
    private float speed = 2f;
    private bool targetSet = false;
    private float energy;
    private float energyLoss = 0.4f;

    private Color restedColor = Color.green;
    private Color tiredColor = Color.yellow;
    private Color tooTiredColor = Color.red;

    public Flying(Bird bird) 
    {
        this.bird = bird;
    }

    public override void Act() 
    {
        Fly();
        CheckEnergy();
    }

    public void Fly() {
        if (bird.transform.position.x >= 9) {
            speed = -speed;
        } else if (bird.transform.position.x <= -9) {
            speed = -speed;
        }
        bird.transform.position += bird.transform.right * -speed * Time.deltaTime;
    }

    private void CheckEnergy()
    {
        energy = bird.getEnergy();
        if (energy > 7f)
        {
            bird.GetComponent<SpriteRenderer>().color = restedColor; 
        } else if (energy > 4f) 
        {
            bird.GetComponent<SpriteRenderer>().color = tiredColor;
        } else {
            bird.GetComponent<SpriteRenderer>().color = tooTiredColor;
        }

        energy -= energyLoss * Time.deltaTime;
        bird.setEnergy(energy);

        if (energy < 1f) {
            bird.setState(bird.getRestingState());
        }
    }
}
