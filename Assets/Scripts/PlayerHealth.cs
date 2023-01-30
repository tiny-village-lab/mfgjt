using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int StartAmount = 100;
    public GameManager gameManager;
    public OozeCounter oozeCounter;

    void Start()
    {
        ResetOoze();
    }

    public void ResetOoze()
    {
        oozeCounter.SetAmount(StartAmount);
    }

    private void FixedUpdate()
    {
        if(oozeCounter.amount == 0)
        {
            gameManager.Died();
        }
    }
}
