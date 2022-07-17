using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;
    public static bool isPaused;
    public static PauseMenu instance;

    private void Awake()
    {
        instance = this;
    }

    private void OnDestroy()
    {
        instance = null;
    }

    public void CheckPauseMenu()
    {
        if (!isPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    private void Resume()
    {
        isPaused = false;

        AudioListener.pause = false;
        Time.timeScale = 1;
        pauseUI.SetActive(false);
    }

    private void Pause()
    {
        isPaused = true;

        AudioListener.pause = true;
        Time.timeScale = 0;
        pauseUI.SetActive(true);
    }

}
