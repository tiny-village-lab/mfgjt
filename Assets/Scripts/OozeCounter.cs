using UnityEngine;

public class OozeCounter : MonoBehaviour
{

    // The number of units of ooze the player has
    public int amount;

    // Set the stock
    public void SetAmount(int units)
    {
        amount = units;
    }

    // Add or subtract (in case of negative value) stock
    public void AddAmount(int units)
    {
        amount += units;
    }

    void FixedUpdate()
    {

    }
}
