using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainController : MonoBehaviour
{

    // Health points
    public int healthPoints;

    // How long it lasts vulnerable
    public float vulnerabilityTime = 15.0f;

    // How much health points you remove when touched by ooze
    private int damageByOozeBall;

    // Gets vulnerable because its shell has been touch
    private bool isVulnerable = false;

    // Next time the Brain becomes untouchable
    private float nextInvicibleTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        WatchVulnerabilityTime();
    }

    private void Die()
    {
        print("dead");
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isVulnerable == false) {
            return;
        }

        if (collision.CompareTag("OozeBall")) {
            healthPoints -= damageByOozeBall;
        }

        if (healthPoints < 0) {
            Die();
        }
    }

    public void SetAsVulnerable()
    {
        print("brain is vulnerable");
        if (isVulnerable == true) {
            return;
        }

        isVulnerable = true;
    }

    private void WatchVulnerabilityTime()
    {
        if (isVulnerable == false) {
            return;
        }

        if (Time.time > nextInvicibleTime ) {
            isVulnerable = false;
        }
    }
}
