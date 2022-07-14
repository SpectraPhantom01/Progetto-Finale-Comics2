using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentTrigger : MonoBehaviour
{
    [SerializeField] Comment comment;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            Instantiate(comment.gameObject, ChatManager.instance.textContainerUI.transform);
            //ChatManager.instance.AddComment(instantiatedComment);
        }
    }
}
