using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private BlockManager[,] blockManagers;
    [SerializeField] Vector3 offSet;
    private Vector3 spawnPos=new Vector2(0,0);
    public int width;
    public int height;
    public GameObject[] blocks;//TODO - change into seperate arrays

    private void Awake() 
    {
        instance=this;
        blockManagers=new BlockManager[width,height];
        for(int i=0 ; i < width;i++)
        {
            for(int j=0 ; j < height;j++)
            {
                GameObject go=Instantiate(blocks[Random.Range(0,2)],spawnPos,Quaternion.identity) as GameObject;
                go.transform.name=i + "," + j;
                blockManagers[i,j]=(go.GetComponent<BlockManager>());
                spawnPos.z+=offSet.z;
            }
            spawnPos.z=0;
            spawnPos.x+=offSet.x;
        }
           
    }
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            CheckBlocks();
        }
    }

    private void CheckBlocks()
    {
        for(int i=0 ; i < width ; i++)
        {
            for(int j=0 ; j<height ; j++)
            {
                if(blockManagers[i,j].isMonster && blockManagers[i,j].isSelected)
                {
                    blockManagers[i,j].gameObject.SetActive(false);
                }
                if(blockManagers[i,j].isMonster && !blockManagers[i,j].isSelected)
                {
                    if( (i>0 && i<width))//Left
                    {
                        
                    }
                    else if(i>=0 && i< width - 1)//right
                    {
                        blockManagers[i,j].GetComponent<MeshRenderer>().material.color=Color.green;
                    }
                }
            }
        }
    }
}
