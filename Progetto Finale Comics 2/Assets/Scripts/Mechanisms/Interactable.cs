using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent action;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>();
        //Record();
    }

    public void Bruh()
    {

    }

    public void Record()
    {
        //Add funzione da svolgere
        //gameManager.interactableListener += Bruh;
    }


}
