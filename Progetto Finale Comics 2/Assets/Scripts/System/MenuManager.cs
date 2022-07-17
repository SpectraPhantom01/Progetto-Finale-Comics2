using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] string levelToLoad;
    bool firstTime;

    private void Awake()
    {
        string activeScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("Menu", activeScene);

        if (firstTime)
        {
            PlayerPrefs.SetString("Level", levelToLoad);
        }
        else
        {
            levelToLoad = PlayerPrefs.GetString("Level");
        }
            
        firstTime = true;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }

}
