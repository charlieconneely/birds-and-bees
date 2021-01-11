using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : BirdState
{
    private Color eatingColor = Color.grey;

    public Eating(Bird bird) 
    {
        this.bird = bird;
    }

    public override void Act()
    {
        Eat();
    }

    private void Eat()
    {
        bird.GetComponent<SpriteRenderer>().color = eatingColor; 
        bird.setState(bird.getRestingState());
    }
}
