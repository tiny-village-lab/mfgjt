using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text oozeText;
    public OozeCounter oozeCounter;

    void Update()
    {
        oozeText.text = "Ooze: " + oozeCounter.amount.ToString() + "/" + oozeCounter.maxAmount.ToString();  
    }
}