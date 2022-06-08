using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apertura : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private void aprichiudi()
    {
        if (animator.GetBool("Apertura"))
            animator.SetBool("Apertura", false);
        else
            animator.SetBool("Apertura", true);
    }

    private void suonoapertura()
    {
        FindObjectOfType<AudioManager>().Play("Apri porta");
    }
    private void suonochiusura()
    {
        FindObjectOfType<AudioManager>().Play("Chiudi porta");
    }
}
