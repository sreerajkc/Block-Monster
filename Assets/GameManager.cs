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
    public int MonsterCount;
    public GameObject[] blocks;//TODO - ADD MORE BLOCKS

    private void Awake()
    {
        instance = this;
        blockManagers = new BlockManager[width, height];
        SpawnBlocks();
    }

    private void SpawnBlocks()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject go = Instantiate(blocks[0], spawnPos, Quaternion.identity) as GameObject;
                go.transform.name = i + "," + j;
                blockManagers[i, j] = (go.GetComponent<BlockManager>());
                if (MonsterCount > 0 && Random.Range(0, 2) == 0)
                {
                    blockManagers[i, j].isMonster = true;
                    MonsterCount--;
                }
                spawnPos.z += offSet.z;
            }
            spawnPos.z = 0;
            spawnPos.x += offSet.x;
        }
    }
}
