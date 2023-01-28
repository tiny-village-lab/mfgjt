using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int currentHealth;

    public OozeCounter oozeCounter;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 50;
        oozeCounter.SetAmount(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
