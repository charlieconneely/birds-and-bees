using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : BirdState
{
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
        // start chase
    }
}
