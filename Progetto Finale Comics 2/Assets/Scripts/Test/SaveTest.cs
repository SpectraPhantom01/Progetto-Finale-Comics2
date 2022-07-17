using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveTest : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            string activeScene = SceneManager.GetActiveScene().name;


            Debug.Log(activeScene);
        }
    }
}
