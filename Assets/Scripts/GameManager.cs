using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIScript UI;
    public PlayerHealth Health;
    public BlendingCams blendCams;

    private void Awake()
    {
        Pause();
    }

    public void LoadScene(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }

    public void Died()
    {
        UI.MainMenu();
        Health.ResetOoze();
        blendCams.blendCams(2, 1);
        LoadScene(0);
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
}
