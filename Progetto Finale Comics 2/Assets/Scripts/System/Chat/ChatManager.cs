using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    public GameObject textContainerUI;
    public static ChatManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void OnDestroy()
    {
        instance = null;
    }

    //public void AddComment(Comment comment)
    //{
    //    textContainerUI.transform.parent = comment.transform;
    //}

}
