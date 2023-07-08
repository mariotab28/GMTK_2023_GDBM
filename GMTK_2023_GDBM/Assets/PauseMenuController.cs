using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool gamePaused;

    void Update()
    {
        bool escapeKeyIsPressed = Input.GetKeyDown(KeyCode.Escape);
        if (escapeKeyIsPressed)
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            gamePaused = true;
            pauseMenu.SetActive(true);
        }
        else if (gamePaused)
        {
            gamePaused = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }
}
