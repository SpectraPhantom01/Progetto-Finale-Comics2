using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header("Game Manager Settings")]
    [SerializeField] Transform currentSpawn;
    public UnityAction interactableListener;
    public UnityAction onRespawn;
    public static GameManager instance;

    private void OnDestroy()
    {
        instance = null;
    }

    private void Awake()
    {
        instance = this;
    }

    public void Respawn(Transform player)
    {
        player.position = currentSpawn.position;
        onRespawn?.Invoke();
    }

    public void InvokeInteractableListener()
    {
        interactableListener?.Invoke();
    }

    //public void ClearInteractableListener()
    //{
        
    //}





}
