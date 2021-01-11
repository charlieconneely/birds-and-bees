using UnityEngine;

public class ChaseController : MonoBehaviour
{
    private bool chaseOn = false;
    private Bee bee;
    private Bird bird;

    private static ChaseController _instance;

    public static ChaseController Instance
    {
        get
        {
            /* check if one exists on the scene */
            _instance = FindObjectOfType<ChaseController>();
            if (_instance == null)
            {
                _instance = new GameObject().AddComponent<ChaseController>();
                return _instance;
            }
            return null;
        }
    }

    private ChaseController() {}

    private void Awake() 
    {
        if (_instance != null) Destroy(this);    
    }

    void Update()
    {
        if (!chaseOn) return;
        
        /* if bee has been eaten */
        if (bee == null) 
        {
            bird.setState(bird.getEatingState());
            Destroy(this);
        }

        if (bee.getEscaped()) 
        {
            bird.setState(bird.getRestingState());
            Destroy(this);
        }
    }

    public void StartChase(Bird bird, Bee bee)
    {
        this.bird = bird;
        this.bee = bee;
        chaseOn = true;
        Chase(bird, bee);
    }

    private void Chase(Bird bird, Bee bee)
    {
        bird.setState(bird.getChasingState());
        bee.setState(bee.getFleeingState());
    }
}
