using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public KeyCode shootButton1;
    public KeyCode shootButton2;
    public float bulletAngle;
    public float bulletSpeed;
    public GameObject bullet;
    public GameObject muzzleFlash;
    
    SpriteRenderer muzzleRenderer;
    Animator muzzleFlashAnimator;
    Transform muzzleTransform;
    Animator shotgunAnimator;
    Transform playerT;
    SpriteRenderer playerS;
    SpriteRenderer shotgunS;
    bool facingLeft;

    private void Start()
    {
        playerT = player.GetComponent<Transform>();
        playerS = player.GetComponent<SpriteRenderer>();
        shotgunS = GetComponent<SpriteRenderer>();
        shotgunAnimator = GetComponent<Animator>();
        muzzleFlashAnimator = muzzleFlash.GetComponent<Animator>();
        muzzleTransform = muzzleFlash.GetComponent<Transform>();
        muzzleRenderer = muzzleFlash.GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        if (playerS.flipX)
        {
            facingLeft = false;
            shotgunS.flipX = true;
            muzzleRenderer.flipX = true;
            transform.position = playerT.position + new Vector3(Mathf.Abs(offset.x),offset.y,0);
            muzzleTransform.position = transform.position + new Vector3(0.55f,0,0);
        }
        else
        {
            facingLeft = true;
            shotgunS.flipX = false;
            muzzleRenderer.flipX = false;
            transform.position = playerT.position + offset;
            muzzleTransform.position = transform.position + new Vector3(-0.55f, 0, 0);
        }

        if (Input.GetKeyDown(shootButton1) | Input.GetKeyDown(shootButton2))
        {
            Shoot();
        }
    }


    public void Shoot()
    {
        GameObject b1 = Instantiate(bullet, transform.position, transform.rotation);
        GameObject b2 = Instantiate(bullet, transform.position, transform.rotation);
        GameObject b3 = Instantiate(bullet, transform.position, transform.rotation);
        ShootBullets(b1, b2, b3);

        muzzleFlashAnimator.SetBool("Shooting", true);
        shotgunAnimator.SetBool("Shooting", true);
        StartCoroutine(StopShootAnimations());
    }



    void ShootBullets(GameObject b1, GameObject b2, GameObject b3)
    {
        Rigidbody2D br1 = b1.GetComponent<Rigidbody2D>();
        Rigidbody2D br2 = b2.GetComponent<Rigidbody2D>();
        Rigidbody2D br3 = b3.GetComponent<Rigidbody2D>();

        if (facingLeft)
        {
            br1.AddForce(new Vector2((bulletSpeed * -1) * Time.deltaTime, bulletAngle* -1 * Time.deltaTime));
            br2.AddForce(new Vector2((bulletSpeed * -1) * Time.deltaTime, 0));
            br3.AddForce(new Vector2((bulletSpeed * -1) * Time.deltaTime, bulletAngle * Time.deltaTime));
        }
        else
        {
            br1.AddForce(new Vector2(bulletSpeed * Time.deltaTime, bulletAngle * -1 * Time.deltaTime));
            br2.AddForce(new Vector2(bulletSpeed * Time.deltaTime, 0));
            br3.AddForce(new Vector2(bulletSpeed * Time.deltaTime, bulletAngle* Time.deltaTime));
        }
    }







    IEnumerator StopShootAnimations()
    {
        yield return new WaitForSeconds(0.15f);
        muzzleFlashAnimator.SetBool("Shooting", false);
        yield return new WaitForSeconds(0.25f);
        shotgunAnimator.SetBool("Shooting", false);
    }
}
