using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;
    [SerializeField] TextMeshProUGUI patchNumber;
    [SerializeField] TextMeshProUGUI patchDescription;
    [SerializeField] PatchNoteSO patchNoteSO;
    [SerializeField] bool pauseOnStart;

    public static bool isPaused;
    public static PauseMenu instance;

    private void Awake()
    {
        instance = this;
        SetPatchNote();

        if (pauseOnStart)
        {
           Pause();
        }        
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

    private void Pause()
    {
        isPaused = true;

        AudioListener.pause = true;
        Time.timeScale = 0;
        pauseUI.SetActive(true);
    }

    private void Resume()
    {
        isPaused = false;

        AudioListener.pause = false;
        Time.timeScale = 1;
        pauseUI.SetActive(false);
    }

    public void LoadMenu()
    {
        string activeScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("Level", activeScene);

        string menuString = PlayerPrefs.GetString("Menu");
        SceneManager.LoadScene(menuString);

        Resume();
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    private void SetPatchNote()
    {
        patchNumber.text = patchNoteSO.name;
        patchDescription.text = patchNoteSO.patch;
    }



}
