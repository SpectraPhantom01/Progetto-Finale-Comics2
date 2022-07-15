using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Comment : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;

    public void InitializeComment(string username, string comment)
    {
        textMesh.text = username + ": " + comment;
    }
}
