using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Bee class. 
* Takes different state objects as class parameters in order to be able to switch dynamically
*/
public class Bee : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float energy = 3f;
    [SerializeField] float nectar = 0;
    [SerializeField] List<GameObject> flowers;
    [SerializeField] GameObject hive;

    private float maxNectar = 10f;

    BeeState _state;
    BeeState atHive;
    BeeState searching;
    BeeState gathering;
    BeeState dancing;

    public Bee() {
        atHive = new AtHive(this);
        searching = new Searching(this);
        gathering = new Gathering(this);
        dancing = new Dancing(this);
        _state = atHive;
    }

    void Update() 
    {
        _state.Act();
    }

    public void setState(BeeState state) 
    {
        _state = state;
    }

    // check if amount has reached limit
    public void checkNectar(float amt) {
        nectar += amt;
        Debug.Log(nectar);
        if (nectar >= maxNectar) {
            setState(dancing);
        }
    }

    public float getSpeed() {return speed;}
    public float  getEnergy() {return energy;}
    public List<GameObject> getFlowers() {return flowers;}
    public GameObject getHive() {return hive;}

    public BeeState getSearchingState() {return searching;}
    public BeeState getGatherState() {return gathering;}
    public BeeState getDancingState() {return dancing;}

    public void setEnergy(float e) {energy = e;}
}
