using UnityEngine;

/**
 * OozeCounter is a class to help managing the amount
 * of ooze the player has
 */
public class OozeCounter : MonoBehaviour
{

    // The number of units of ooze the player has
    public int amount;

    private float nextActionTime = 0.0f;
    public float period = 5.0f;

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

    public int GetAmount()
    {
        return amount;
    }

    void FixedUpdate()
    {
        if (Time.time > nextActionTime ) {
            nextActionTime += period;
            
            if (amount > 0) {
                AddAmount(-5);
            }

            if (amount < 0) {
                amount = 0;
            }
        }
    }
}
