using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OozePickup : MonoBehaviour
{

    public OozeCounter oozeScript;
    public float rotateSpeed;
    [SerializeField] int dropAmount;
    [SerializeField] float size;

    private void Start()
    {
        dropAmount = Random.Range(1, 10);

        if (dropAmount <= 3)
        {
            size = 1;
        }
        if(dropAmount >= 4 && dropAmount <= 7)
        {
            size = 2;
        }
        if (dropAmount >= 8 && dropAmount <= 10)
        {
            size = 3;
        }
        transform.localScale = new Vector3(size/2,size/2,size/2);
    }


    private void Update()
    {
        transform.Rotate(0, rotateSpeed*Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            oozeScript.AddAmount(dropAmount);
            Debug.Log(dropAmount + " ooze picked up.");
            Destroy(gameObject);
        }
    }
}
