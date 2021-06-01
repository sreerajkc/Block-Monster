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
        GetComponent<MeshRenderer>().material.color=Color.red;
        blockManager=GetComponent<BlockManager>();
    }
   private void OnMouseDown()
    {
        isGoingToEat=false;
        if(blockManager.isMonster)
        {
            EnemyMove();
            isGoingToEat=true;
        }
    }
    private void EnemyMove()
    {
        if (CastRay(transform.right))//right
        {
            Debug.DrawRay(transform.position,transform.right,Color.green,1f);
        }
        else if (CastRay(-transform.right))//left
        {
            Debug.DrawRay(transform.position,-transform.right,Color.green,1f);
        }
        else if (CastRay(transform.forward))//forward
        {
            Debug.DrawRay(transform.position,transform.forward,Color.green,1f);
        }
        else if (CastRay(-transform.forward))//backward
        {
            Debug.DrawRay(transform.position,-transform.forward,Color.green,1f);
        }
        else
        {
            //do nothing......
        }
    }
    private void Update() 
   {
       if(isGoingToEat)
       {
            transform.position=Vector3.Lerp(transform.position,hitObjPos,.1f);
       }
    }
   private bool CastRay(Vector3 Direction)
   {
       RaycastHit hit;
       bool isHit=Physics.Raycast(transform.position,Direction,out hit);
       if(isHit && hit.collider.CompareTag("Friends"))
       {
           hit.collider.gameObject.SetActive(false);
           hitObjPos=hit.transform.position;
           return isHit;
       }
       else
       {
           hitObjPos=transform.position;
           return false;
       }
   }
}
