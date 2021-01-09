using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Bird class. 
* Takes different state objects as class parameters in order to be able to switch dynamically
*/
public class Bird : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float energy = 10f;
    [SerializeField] GameObject nest;

    BirdState flying;
    BirdState resting;
    BirdState _state;

    public Bird() {
        flying = new Flying(this);
        resting = new Resting(this);
         _state = resting;
    }

    public void setState(BirdState state) 
    {
        _state = state;
    }

    void Update() 
    {
        _state.Act();    
    }

    public BirdState getFlyingState() {return flying;}
    public BirdState getRestingState() {return resting;}

    public float getEnergy() {return energy;}
    public float getSpeed() {return speed;}
    public GameObject getNest() {return nest;}

    public void setEnergy(float e) {energy = e;}
}
