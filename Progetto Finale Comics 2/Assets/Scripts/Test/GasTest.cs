using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasTest : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GasManager.gasCounter == 0)
        {
            GasManager.instance.StartCountdown();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GasManager.gasCounter == 0)
        {
            GasManager.instance.ResetCountdown();
        }
    }

}
