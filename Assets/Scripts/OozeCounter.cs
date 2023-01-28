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

    // Period in seconds when we remove some ooze
    public float period = 5.0f;

    // The amount to remove every "period" time
    public int amountToRemovePeriodically = 5;

    // Maximum amount of ooze
    public int maxAmount = 200;

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
        decreaseOozePeriodically();
    }

    /**
      * Based on the "period" variable
      * remove some ooze periodically
      */
    void decreaseOozePeriodically()
    {
        if (Time.time > nextActionTime ) {
            nextActionTime += period;
            
            if (amount > 0) {
                AddAmount(amountToRemovePeriodically * -1);
            }

            // In case the amount gets lower than 0, we set it 
            // to zero as a very minimum
            if (amount < 0) {
                amount = 0;
            }
        }
    }
}
