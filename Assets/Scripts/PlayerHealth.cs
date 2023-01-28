using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public OozeCounter oozeCounter;

    // Start is called before the first frame update
    void Start()
    {
        oozeCounter.SetAmount(100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
