using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public bool isMonster;
    public bool isSelected;


    private void Start() 
    {
        if(isMonster)
        {
            gameObject.AddComponent<MonsterController>();
        }
        else
        {
            gameObject.AddComponent<FriendController>();
        }
    }
    
}
