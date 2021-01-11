using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : BirdState
{
    private Bee bee;
    private float speed;
    private Vector2 beePos;

    private Color chasingColor = Color.black;

    public Chasing(Bird bird)
    {
        this.bird = bird;
    }

    public override void Act()
    {
        Chase();
    }

    private void Chase()
    {
        bee = bird.getBee();
        if (bee == null) return; 
        speed = bird.getSpeed();
        beePos = bee.transform.position; 

        bird.GetComponent<SpriteRenderer>().color = chasingColor; 
        
        float step = speed * Time.deltaTime;
        bird.transform.position = Vector2.MoveTowards(bird.transform.position, beePos, step);
    }
}
