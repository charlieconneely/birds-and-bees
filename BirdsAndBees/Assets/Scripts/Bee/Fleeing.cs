using UnityEngine;

/* 
* Fleeing state
*/
public class Fleeing : BeeState
{
    private GameObject hive;
    private ChaseController chaseController;
    private float speed;
    private Color color = Color.grey;

    public Fleeing(Bee bee)
    {
        this.bee = bee;
    }

    public override void Act()
    {
        Flee();
    }

    private void Flee()
    {
        bee.GetComponent<SpriteRenderer>().color = color; 
        hive = bee.getHive();
        speed = bee.getSpeed();

        float step = speed * Time.deltaTime;
        bee.transform.position = Vector2.MoveTowards(bee.transform.position, hive.transform.position, step);

        if (bee.transform.position.x == hive.transform.position.x 
            && bee.transform.position.y == hive.transform.position.y)
        {
            bee.setState(bee.getDancingState());
        }
    }
}
