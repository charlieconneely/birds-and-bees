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
    private bool escaped = false;

    BeeState _state;
    BeeState atHive;
    BeeState searching;
    BeeState gathering;
    BeeState dancing;
    BeeState fleeing;

    public Bee() {
        atHive = new AtHive(this);
        searching = new Searching(this);
        gathering = new Gathering(this);
        dancing = new Dancing(this);
        fleeing = new Fleeing(this);
        _state = atHive;
    }

    void Update() 
    {
        _state.Act();
        checkIfAtHive();
    }

    public void setState(BeeState state) 
    {
        _state = state;
    }

    private void checkIfAtHive()
    {
        if (transform.position.x == hive.transform.position.x
            && transform.position.y == hive.transform.position.y)
        {
            escaped = true;
        } else {
            escaped = false;
        }
    }

    /* if we collide with the bird's polygon collider - die */
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetType() == typeof(PolygonCollider2D))
        {
            Destroy(gameObject);
        }
    }

    public float getSpeed() {return speed;}
    public float getEnergy() {return energy;}
    public bool getEscaped() {return escaped;}
    public List<GameObject> getFlowers() {return flowers;}
    public GameObject getHive() {return hive;}

    public BeeState getSearchingState() {return searching;}
    public BeeState getGatherState() {return gathering;}
    public BeeState getDancingState() {return dancing;}
    public BeeState getFleeingState() {return fleeing;}

    public void setEnergy(float e) {energy = e;}
}
