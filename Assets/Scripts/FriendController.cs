using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.pop);
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        blockManager.animator.SetTrigger("isDone");
        GameManager.instance.UpdateSaved();
        StartCoroutine(DisableObject());
    }
    IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(.8f);
        gameObject.SetActive(false);
    }
    
}
