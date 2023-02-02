using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{

    public BossManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // @todo replace "Player" by Fireball
        if (collision.CompareTag("Player")) {
            manager.ShellHasBeenHit();
        }
    }
}
