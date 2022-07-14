using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Comment : MonoBehaviour
{
    [SerializeField] CommentSO commentSO;
    [SerializeField] TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh.text = commentSO.comment;
    }
}
