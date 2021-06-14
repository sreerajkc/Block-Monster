using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class GameManager : MonoBehaviour
{
    Camera cam;
    public static GameManager instance;
    private BlockManager[,] blockManagers;
    private UIManager uiManager;
    [SerializeField] Vector3 offSet;
    private Vector3 spawnPos=new Vector2(0,0);
    public int width;
    public int height;
    public int monsterCount;
    public int friendsToSave;
    public int currentlyAlive;
    public GameObject[] blocks;//TODO - ADD MORE BLOCKS


    private void Awake()
    {
        instance = this;
        uiManager=FindObjectOfType<UIManager>();
        uiManager.SetMonsterNo(monsterCount);
        uiManager.SetSavedNo(friendsToSave);
        uiManager.SetLevelNo(SceneManager.GetActiveScene().buildIndex);
        blockManagers = new BlockManager[width, height];
        SpawnBlocks();
    }

    private void SpawnBlocks()
    {
        currentlyAlive=(width*height)-monsterCount;
        cam = Camera.main;
        cam.GetComponent<CameraController>().ChangeCamerPosition(new Vector2(width-1,height-1));
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject go = Instantiate(blocks[0], spawnPos, Quaternion.identity) as GameObject;
                go.transform.name = i + "," + j;
                blockManagers[i, j] = (go.GetComponent<BlockManager>());
                if (monsterCount > 0 && Random.Range(0, 2) == 0)
                {
                    blockManagers[i, j].isMonster = true;
                    monsterCount--;
                }
                spawnPos.z += offSet.z;
            }
            spawnPos.z = 0;
            spawnPos.x += offSet.x;
        }
    }
    public void UpdateSaved()
    {
        if(friendsToSave > 1)
        {
            friendsToSave--;
            currentlyAlive--;
            uiManager.SetSavedNo(friendsToSave);
        }
        else
        {
            ChangeLevel();// if saved all change to next level
        }
    }
    public void AliveCheck()
    {
        currentlyAlive--;
        if(currentlyAlive<friendsToSave)
        {
            uiManager.GameOver();
        }
    }
    public void ChangeLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex <= SceneManager.sceneCountInBuildSettings)
        {
            uiManager.Win();
            PlayerPrefs.SetInt("CurrentLevel",SceneManager.GetActiveScene().buildIndex);
            StartCoroutine(LoadScene());
        }
        else
        {
            uiManager.GameCompleted();
        }
    }
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}
