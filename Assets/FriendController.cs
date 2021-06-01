using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendController : MonoBehaviour
{
    BlockManager blockManager;
    void Start()
    {
        tag="Friends";
        GetComponent<MeshRenderer>().material.color=Color.blue;
    }

    private void OnMouseDown() 
    {
        gameObject.SetActive(false);
    }
}
