using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float speed;
    Vector2 direction;
    Vector3 goal;
    string currentGoal;

    private void Start()
    {
        pointA.transform.position.Set(pointA.transform.position.x, 2f , 0);
        pointB.transform.position.Set(pointB.transform.position.x, 2f, 0);

        goal = pointB.transform.position;
        currentGoal = "B";
    }
    void Update()
    {
        direction = goal-transform.position;

        transform.Translate(direction.normalized*Time.deltaTime*speed);

        if (direction.magnitude < 0.5f)
        {
            if(currentGoal == "B")
            {
                goal = pointA.transform.position;
                currentGoal = "A";
            }
            else
            {
                goal = pointB.transform.position;
                currentGoal = "B";
            }
        }
        
    }
}
