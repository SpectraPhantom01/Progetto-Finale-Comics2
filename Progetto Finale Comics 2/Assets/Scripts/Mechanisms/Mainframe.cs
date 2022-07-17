using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Mainframe : MonoBehaviour
{
    //[SerializeField] int sceneIndex;
    PlayableDirector director;

    private void Start()
    {
        director = GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //director.Play();
            //SceneManager.LoadScene(sceneIndex);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
