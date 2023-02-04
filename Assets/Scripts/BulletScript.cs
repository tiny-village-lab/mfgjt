using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "IgnoreBullet" && collision.gameObject.name != "WorldBorder")
        {
            Destroy(gameObject);
        }
    }
}
