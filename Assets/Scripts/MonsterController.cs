using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
   Vector3 hitObjPos;
   BlockManager blockManager; 
   bool isGoingToEat=false;

    private void Start() 
    {
        tag="Monsters";
        blockManager=GetComponent<BlockManager>();
    }
   private void OnMouseDown()
    {
        StartCoroutine(TurnIntoMonsterTime());
        EnemyMove();
        blockManager.TurnIntoMonster();
    }
    private void EnemyMove()
    {
        //checking and casting at the same time
        if (CastRay(transform.right))//right
        {
            //do nothing
        }
        else if (CastRay(-transform.right))//left
        {
            //do nothing
        }
        else if (CastRay(transform.forward))//forward
        {
            //do nothing
        }
        else if (CastRay(-transform.forward))//backward
        {
            //do nothing
        }
    }
    private void Update() 
   {
       if(isGoingToEat)
       {
           
           if(transform.position!=hitObjPos)
           {
               transform.position=Vector3.Lerp(transform.position,hitObjPos,.05f);
               blockManager.enabled=false;
           }
           else
           {
               isGoingToEat=false;
               blockManager.enabled=false;
               blockManager.isClicked=false;
               StartCoroutine(blockManager.Blinking());
           }
       }
    }
   private bool CastRay(Vector3 Direction)
   {
       RaycastHit hit;
       bool isHit=Physics.Raycast(transform.position,Direction,out hit);
       if(isHit && hit.collider.CompareTag("Friends"))
       {
           hitObjPos=hit.collider.transform.position;
           hit.collider.GetComponent<BlockManager>().Scared();
           hit.collider.GetComponent<BlockManager>().enabled=false;
           StartCoroutine("Die",hit);
           return isHit;
       }
       else
       {
           hitObjPos=transform.position;
           return false;
       }
   }
   IEnumerator Die(RaycastHit hit)
   {
            yield return new WaitForSeconds(.5f);
            hit.collider.GetComponent<BlockManager>().animator.SetTrigger("isDone");
            yield return new WaitForSeconds(.5f);
            hit.collider.gameObject.SetActive(false);
   }
   IEnumerator TurnIntoMonsterTime()//one ienum for two purpses
   {
        yield return new WaitForSeconds(.5f);
        isGoingToEat=true;
   }
   
}
