using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenButtons : MonoBehaviour
{

    public void DeathScreenBackToStart()
    {
        SceneManager.LoadScene("BaseMenu");
        Time.timeScale = 1f;
    }

    public void DeathScreenQuitGame()
    {
        Application.Quit();
    }
}
