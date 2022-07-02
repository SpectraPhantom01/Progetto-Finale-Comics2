using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uimanager : MonoBehaviour
{
    [SerializeField]
    float duration = 1;
    bool active = false;
    float width = 10000;
    int direction = 1;

    private void FixedUpdate()
    {
        if (active)
        {
            this.gameObject.GetComponent<RectTransform>().Translate(new Vector3(direction, 0, 0) * duration);
            width -= 1*duration;
            Debug.Log(width);
            if (width <= 0)
                active = false;
        }
    }

    public void Slide() 
    {
        active = true;
        width = this.gameObject.GetComponent<RectTransform>().sizeDelta.x;
        Debug.Log(width);
        direction *= -1;
        


    }
}
