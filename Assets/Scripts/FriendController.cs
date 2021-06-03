using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendController : MonoBehaviour
{
    BlockManager blockManager;
    void Start()
    {
        tag="Friends";
        blockManager=GetComponent<BlockManager>();
    }

    private void OnMouseDown() 
    {
        blockManager.animator.SetTrigger("isDone");
        StartCoroutine(DisableObject());
    }
    IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(.8f);
        gameObject.SetActive(false);
    }
    
}
