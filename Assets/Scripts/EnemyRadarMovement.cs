using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadarMovement : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle")) {
            SendMessageUpwards("Jump");
        }
    }
}
