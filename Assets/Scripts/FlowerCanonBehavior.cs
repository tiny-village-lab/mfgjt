using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerCanonBehavior : MonoBehaviour
{

    public ProjectileBehavior projectilePrefab;

    private float nextActionTime = 0.0f;

    // Period in seconds when we remove some ooze
    public float shootingFrequency = 5.0f;

    public Transform launchOffset;

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Time.time > nextActionTime ) {
            nextActionTime += shootingFrequency;
            
            Instantiate(projectilePrefab, launchOffset.position, transform.rotation);
        }
    }
}
