using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{

    [Header("Menus")]
    public GameObject pauseMenu;
    public GameObject resumeMenu;
    public GameObject deathMenu;

    [Header("PauseKey")]
    public KeyCode pauseKey;

    public static bool isPaused;

    public static PauseMenuScript Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    private void Start()
    {
        pauseMenu.SetActive(false);
        deathMenu.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(pauseKey) && !deathMenu.activeSelf)
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

    public void DeathScreen()
    {
        deathMenu.SetActive(true);
        pauseMenu.SetActive(false);
        resumeMenu.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
