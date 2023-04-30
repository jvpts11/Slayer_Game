using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{

    [Header("Menus")]
    public GameObject pauseMenu;
    public GameObject resumeMenu;

    [Header("PauseKey")]
    public KeyCode pauseKey;

    public static bool isPaused;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(pauseKey))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        resumeMenu.SetActive(false);
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        resumeMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
    }
}
