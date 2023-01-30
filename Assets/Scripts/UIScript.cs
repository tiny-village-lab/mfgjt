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
    public GameObject buttonPanel;
    public GameObject optionsPanel; 

    void Update()
    {
        oozeText.text = "Ooze: " + oozeCounter.amount.ToString() + "/" + oozeCounter.maxAmount.ToString();

        if (Input.GetKeyDown(KeyCode.Escape) && optionsPanel.active == true)
        {
            buttonPanel.SetActive(true);
            optionsPanel.SetActive(false);
        }
    }

    public void Play()
    {
        blendScript.blendCams(1, 2);
        menuButtons.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        buttonPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }
}
