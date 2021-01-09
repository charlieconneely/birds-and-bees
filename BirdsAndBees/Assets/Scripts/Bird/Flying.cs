using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
* Flying state
*/
public class Flying : BirdState
{
    private float speed;
    private float energy;
    private float energyLoss = 0.4f;
    private bool initialized = false;

    private Color restedColor = Color.green;
    private Color tiredColor = Color.yellow;
    private Color tooTiredColor = Color.red;

    private float restedMin, tiredMin, tooTiredMin;

    private Vector2 pointA;
    private Vector2 pointB;
    private Vector2 target; 
    private Vector2 other;

    public Flying(Bird bird) 
    {
        this.bird = bird;
    }

    public override void Act() 
    {
        if (!initialized) {
            Initialize();
            initialized = true;
        }
        Fly();
        CheckEnergy();
    }

    private void Fly() {
        speed = bird.getSpeed();
        
        float step = speed * Time.deltaTime;
        bird.transform.position = Vector2.MoveTowards(bird.transform.position, target, step);

        if (bird.transform.position.x == pointA.x) {
            target = pointB;
        } else if (bird.transform.position.x == pointB.x) {
            target = pointA;
        }
    }

    private void CheckEnergy()
    {    
        energy = bird.getEnergy();

        /* Define energy based on color */
        if (energy > restedMin)
        {
            bird.GetComponent<SpriteRenderer>().color = restedColor; 
        } else if (energy > tiredMin) 
        {
            bird.GetComponent<SpriteRenderer>().color = tiredColor;
        } else {
            bird.GetComponent<SpriteRenderer>().color = tooTiredColor;
        }

        energy -= energyLoss * Time.deltaTime;
        bird.setEnergy(energy);

        /* if energy is less than 10% - get back to the nest */
        if (energy < tooTiredMin) {
            bird.setState(bird.getRestingState());
        }
    }

    private void Initialize() {
        energy = bird.getEnergy();
        restedMin = energy * 0.7f;
        tiredMin = energy * 0.4f;
        tooTiredMin = energy * 0.1f;

        if (bird.transform.position.x > 0f) {
            pointA = new Vector2(-9f, bird.transform.position.y);
            pointB = new Vector2(9f, bird.transform.position.y);
        } else {
            pointA = new Vector2(9f, bird.transform.position.y);
            pointB = new Vector2(-9f, bird.transform.position.y);
        }
        target = pointA;
    }
}
