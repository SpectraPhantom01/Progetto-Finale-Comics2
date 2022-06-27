using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apertura : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void aprichiudi()
    {
        if (animator.GetBool("Apertura"))
            animator.SetBool("Apertura", false);
        else
            animator.SetBool("Apertura", true);
    }

    private void suonoapertura()
    {
        AudioManager.instance.Play("Apri porta");
    }
    private void suonochiusura()
    {
        AudioManager.instance.Play("Chiudi porta");
    }
}
