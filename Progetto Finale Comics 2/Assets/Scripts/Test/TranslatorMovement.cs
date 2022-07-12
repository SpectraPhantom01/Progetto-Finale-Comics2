using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslatorMovement : MonoBehaviour
{
    [Header("Translator Settings")]
    [SerializeField] float duration;
    [SerializeField] Transform[] points;
    [SerializeField] int startingIndex;
    AudioSource sound;
    int index;

    public bool active = true;

    int i = 1;

    private void Start()
    {
        ResetPosition();
        GameManager.instance.onRespawn += ResetPosition;

        if (sound) 
            sound.Play();
    }

    private void FixedUpdate()
    {
        if (active)
        {
            if (Vector2.Distance(transform.position, points[index].position) < 0.02f)
            {
                bool result = false;
                result = CheckBounds();

                if (!result)
                    index += i;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, points[index].position, duration * Time.fixedDeltaTime);
            }
        }
    }

    private bool CheckBounds()
    {
        if (index == points.Length - 1)
        {
            i = -1;
            return false;
        }
        else if (index == 0)
        {
            i = 1;
            return false;
        }
        return true;
    }

    public void ObjectState()
    {
        if (!active)
        {
            active = true;
        }
        else
        {
            active = false;
            ResetPosition();
        }
    }

    private void ResetPosition()
    {        
        index = startingIndex;
        i = 1;

        transform.position = points[index].position;
        transform.rotation = Quaternion.identity;
    }


}
