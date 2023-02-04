using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public KeyCode shootButton1;
    public KeyCode shootButton2;
    public float bulletSpeed;
    public GameObject bullet;

    Transform playerT;
    SpriteRenderer playerS;
    SpriteRenderer shotgunS;
    bool facingLeft;

    private void Start()
    {
        playerT = player.GetComponent<Transform>();
        playerS = player.GetComponent<SpriteRenderer>();
        shotgunS = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (playerS.flipX)
        {
            facingLeft = false;
            shotgunS.flipX = true;
            transform.position = playerT.position + new Vector3(Mathf.Abs(offset.x),offset.y,0);
        }
        else
        {
            facingLeft = true;
            shotgunS.flipX = false;
            transform.position = playerT.position + offset;
        }

        if (Input.GetKeyDown(shootButton1) | Input.GetKeyDown(shootButton2))
        {
            Shoot();
        }
    }


    public void Shoot()
    {
        
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody2D bulletRigid = newBullet.GetComponent<Rigidbody2D>();

        if (facingLeft)
        {
            bulletRigid.AddForce(new Vector2((bulletSpeed*-1) * Time.deltaTime, 0));
        }
        else
        {
            bulletRigid.AddForce(new Vector2(bulletSpeed* Time.deltaTime, 0));
        }
    }
}
