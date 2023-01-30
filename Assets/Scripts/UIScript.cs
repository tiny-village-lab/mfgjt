using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text oozeText;
    public GameObject menuButtons;
    public OozeCounter oozeCounter;
    public BlendingCams blendScript;

    void Update()
    {
        oozeText.text = "Ooze: " + oozeCounter.amount.ToString() + "/" + oozeCounter.maxAmount.ToString();
    }

    public void Play()
    {
        blendScript.blendCams(1, 2);
        menuButtons.SetActive(false);
    }
}
