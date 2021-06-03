using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class BlockManager : MonoBehaviour
{
    [SerializeField] Texture eyesClosed,Excited,MonsterFace,scaryFace;
    [SerializeField] GameObject plane;
    [HideInInspector] public bool isMonster,isEyesOpened=true,isMouseExit=true,isClicked=false;
    [SerializeField] Color[] colors;
    [HideInInspector]public Animator animator;
    Texture eyesOpened;
    private void Start() 
    {
        GetComponent<MeshRenderer>().material.color=colors[Random.Range(0,colors.Length)];
        eyesOpened=plane.GetComponent<MeshRenderer>().material.GetTexture("_BaseMap");
        animator=GetComponent<Animator>();
        if(isMonster)
        {
            gameObject.AddComponent<MonsterController>();
        }
        else
        {
            gameObject.AddComponent<FriendController>();
        }
        StartCoroutine("Blinking");
    }
    private void OnMouseEnter() 
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        animator.SetTrigger("isOver");
        isMouseExit=false;
    }
    private void OnMouseOver() 
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(!isClicked)
        {
            plane.GetComponent<MeshRenderer>().material.SetTexture("_BaseMap",Excited);
        }
    }
    private void OnMouseExit()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        isMouseExit=true;
        StartCoroutine("Blinking");
    }
    public IEnumerator Blinking()
    {
        if(isMouseExit && !isClicked)
        {
            if(isEyesOpened)
            {
                yield return new WaitForSeconds(Random.Range(1,5));
                plane.GetComponent<MeshRenderer>().material.SetTexture("_BaseMap",eyesClosed);
                isEyesOpened=false;
                StartCoroutine("Blinking");
            }
            else
            {
                yield return new WaitForSeconds(.4f);
                plane.GetComponent<MeshRenderer>().material.SetTexture("_BaseMap",eyesOpened);
                isEyesOpened=true;
                StartCoroutine("Blinking");
            }
        }
    }
    public void TurnIntoMonster()
    {
        isClicked=true;
        plane.GetComponent<MeshRenderer>().material.SetTexture("_BaseMap",MonsterFace);
    }
    public void Scared()
    {
        plane.GetComponent<MeshRenderer>().material.SetTexture("_BaseMap",scaryFace);

    }
}
