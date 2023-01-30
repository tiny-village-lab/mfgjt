using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIScript UI;
    public PlayerHealth Health;

    public void LoadScene(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }

    public void Died()
    {
        UI.MainMenu();
        Health.ResetOoze();
    }
}
