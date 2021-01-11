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
    private Bee bee;

    // private ChaseController chaseController;

    BirdState flying;
    BirdState resting;
    BirdState chasing;
    BirdState eating;
    BirdState _state;

    public Bird() {
        flying = new Flying(this);
        resting = new Resting(this);
        chasing = new Chasing(this);
        eating = new Eating(this);
         _state = resting;
    }

    void Start()
    {
        // chaseController = FindObjectOfType<ChaseController>();
    }

    void Update() 
    {
        _state.Act();    
    }

    public void setState(BirdState state) 
    {
        _state = state;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        bee = other.GetComponentInChildren<Bee>();
        /* if the bee is not at the hive... */
        if (!bee.getEscaped() && bee != null)
        {
            /* if we have enough energy...*/
            if (energy > 1f)
            {
                /* start the chase */
                ChaseController chaseController = ChaseController.Instance;
                if (chaseController != null) chaseController.StartChase(this, bee);
            }
        }
    }

    public BirdState getFlyingState() {return flying;}
    public BirdState getRestingState() {return resting;}
    public BirdState getEatingState() {return eating;}
    public BirdState getChasingState() {return chasing;}

    public float getEnergy() {return energy;}
    public float getSpeed() {return speed;}
    public GameObject getNest() {return nest;}
    public Bee getBee() {return bee;}

    public void setEnergy(float e) {energy = e;}  
}
