using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextMail : MonoBehaviour
{
    [SerializeField]
    private GameObject mail;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject fader;
    [SerializeField]
    private float transitionTime = 1f;
    public void Next()
    {
        animator.SetTrigger("Start");
        StartCoroutine(sincronizza());
    }

    IEnumerator sincronizza()
    {
        yield return new WaitForSeconds(transitionTime);
        if (mail != null)
        {
            mail.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else
            Load();
    }
    public void Load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
