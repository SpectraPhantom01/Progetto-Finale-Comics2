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

    public void Respawn(Transform player)
    {
        player.position = currentSpawn.position;
    }

    public void InvokeInteractableListener()
    {
        interactableListener?.Invoke();
    }





}
