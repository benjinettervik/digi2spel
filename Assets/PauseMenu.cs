using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] private bool isPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            ActiveMenu();
        }

        else
        {
            DeactiveMenu();
        }
    }
    void ActiveMenu()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    }

    void DeactiveMenu()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
    }

}
