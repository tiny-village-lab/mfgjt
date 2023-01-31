using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float speed;
    public Transform[] waypoints;
    public bool isJumping = false;

    private int destinationIndex = 0;
    private Transform target;

    [Header("Stats")]
    public float jumpPower;

    public Rigidbody2D rb;

    private void Start()
    {
        target = waypoints[0];
    }

    void Update()
    {
        // Moves the guy to its destination
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // If target is almost reached, target becomes the next waypoint
        if (Vector3.Distance(transform.position, target.position) < 0.3f) {
            destinationIndex = (destinationIndex + 1) % waypoints.Length;
            target = waypoints[destinationIndex];
        }
    }

    void Jump()
    {
        if (isJumping == true) {
            return;
        }

        rb.AddForce(new Vector2(0f, jumpPower));
        isJumping = false;
    }
}
