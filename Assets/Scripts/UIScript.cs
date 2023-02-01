using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text oozeText;
    public OozeCounter oozeCounter;
    public BlendingCams blendScript;
    public GameObject buttonPanel;
    public GameObject optionsPanel;
    public GameManager gameManager;

    private void Awake()
    {
        oozeText.gameObject.SetActive(false);
        buttonPanel.SetActive(true);
        optionsPanel.SetActive(false);

    }
    void Update()
    {
        oozeText.text = "Ooze: " + oozeCounter.amount.ToString() + "/" + oozeCounter.maxAmount.ToString();

        if (Input.GetKeyDown(KeyCode.Escape) && optionsPanel.activeSelf == true)
        {
            MainMenu();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && optionsPanel.activeSelf == false)
        {
            gameManager.Pause();
            MainMenu();
            blendScript.blendCams(2, 1);
        }
    }

    public void Play()
    {
        blendScript.blendCams(1, 2);
        buttonPanel.SetActive(false);
        oozeText.gameObject.SetActive(true);
        gameManager.Resume();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        buttonPanel.SetActive(false);
        optionsPanel.SetActive(true);
        oozeText.gameObject.SetActive(false);
    }    

    public void MainMenu()
    {
        buttonPanel.SetActive(true);
        optionsPanel.SetActive(false);
        oozeText.gameObject.SetActive(false);
    }
}
