using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
* Resting state
*/
public class Resting : BirdState
{
    private GameObject nest;
    private float energy;
    private float speed;
    private float energyIncrease = 0.3f;
    private bool atNest = true;
    private Color restingColor = Color.magenta;

    public Resting(Bird bird) 
    {
        this.bird = bird;
    }

    public override void Act() 
    {
        bird.GetComponent<SpriteRenderer>().color = restingColor; 
        GetBackToNest();
    }

    private void GetBackToNest() {
        if (atNest) {
            Rest();
            return;
        }
        nest = bird.getNest();
        speed = bird.getSpeed();

        float step = speed * Time.deltaTime;
        bird.transform.position = Vector2.MoveTowards(bird.transform.position, nest.transform.position, step);

        if (bird.transform.position.x == nest.transform.position.x &&
        bird.transform.position.y == nest.transform.position.y) {
            atNest = true;
        }
    }

    private void Rest()
    {
        energy = bird.getEnergy();
        if (energy < 10) {
            energy += energyIncrease * Time.deltaTime;
            bird.setEnergy(energy);
        }
        Debug.Log(energy);
        if (energy >= 10) {
            atNest = false;
            bird.setState(bird.getFlyingState());
        }
    }
}
