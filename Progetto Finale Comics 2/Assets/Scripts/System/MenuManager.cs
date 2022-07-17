using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] string levelToLoad;

    private void Awake()
    {
        string activeScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("Menu", activeScene);
    }


    public void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }

}
