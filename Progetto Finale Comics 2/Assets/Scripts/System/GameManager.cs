using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform currentSpawn;

    public void Respawn(Transform player)
    {
        player.position = currentSpawn.position;
    }
}
