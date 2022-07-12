using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("Platform Settings")]    
    [SerializeField] float duration;
    [SerializeField] float stasisTime = 1;
    [SerializeField] Transform[] points;
    [SerializeField] int startingIndex;
    int index;

    GameObject player;
    public bool active = true;
    public bool onTouch = false;

    int i = 1;

    private void Start()
    {
        ResetPlatform();
        GameManager.instance.onRespawn += ResetPlatform;
    }

    private void FixedUpdate()
    {
        if (active)
        {
            if (Vector2.Distance(transform.position, points[index].position) < 0.02f)
            {
                bool result = false;
                result = CheckTeleport();

                if (!result)
                    index += i;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, points[index].position, duration * Time.fixedDeltaTime);
            }
        }
    }

    private bool CheckTeleport()
    {
        if (index == points.Length - 1)
        {
            active = false;
            Invoke("ResetPlatform", stasisTime);

            if(player)
                player.transform.parent = null;

            return true;
        }
        return false;
    }

    //private void TeleportPlatform()
    //{
    //    index = 0;
    //    transform.position = points[0].position;
    //}

    public void PlatformState()
    {
        if (!active)
        {
            active = true;
        }
        else
        {
            ResetPlatform();       
        }
    }

    private void ResetPlatform()
    {
        active = false;
        index = startingIndex;
        i = 1;

        transform.position = points[index].position;
        transform.rotation = Quaternion.identity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.transform.SetParent(gameObject.transform, true);
            player = collision.gameObject;

            if (onTouch)
                active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.transform.parent = null;
            player = null;
        }
    }
}
