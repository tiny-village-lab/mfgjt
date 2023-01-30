using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OozePickupAnimation : MonoBehaviour
{
    public float rotateSpeed = 50;
    public int dropAmount;

    int size;

    void Start()
    {
        dropAmount = Random.Range(1, 10);

        if (dropAmount <= 3)
        {
            size = 1;
        }
        if (dropAmount >= 4 && dropAmount <= 7)
        {
            size = 2;
        }
        if(dropAmount >= 8)
        {
            size = 3;
        }

        transform.localScale = new Vector3(size, size, size);
    }

    private void Update()
    {
        transform.Rotate(0, rotateSpeed* Time.deltaTime, 0);
    }
}