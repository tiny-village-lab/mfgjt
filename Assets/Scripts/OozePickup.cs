using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OozePickup : MonoBehaviour
{
    public OozeCounter oozeScript;

    int dropAmount;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if player collides with ooze
        if (collision.collider.gameObject.tag == "OozePickUp")
        {
            dropAmount = collision.gameObject.GetComponent<OozePickupAnimation>().dropAmount;
            // add ooze
            oozeScript.AddAmount(dropAmount);
            Debug.Log(dropAmount + " ooze picked up.");
            // destroy gameObject
            Destroy(collision.gameObject);
        }
    }


}
