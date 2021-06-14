using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu,levelMenu,pauseMenu,inGameUI,gameOver,winScreen,completed,backButton;
    [SerializeField] TextMeshProUGUI monsterNo,savedNo,levelNo;
    [SerializeField] GameObject[] levels;

    private void Start() 
    {
        for(int i=0;i<levels.Length;i++)
        {
            if(i<PlayerPrefs.GetInt("CurrentLevel"))
            {
                levels[i].GetComponent<LevelUImanager>().tick.enabled=true;
            }
            else if(i>PlayerPrefs.GetInt("CurrentLevel") )
            {
                levels[i].GetComponent<Button>().interactable=false;
                levels[i].GetComponent<LevelUImanager>().levelNo.color=new Vector4(0.9960784f,0.8235294f,.2470588f,.20f);
            }
        }
    }
    public void Play()
    {
        levelMenu.SetActive(true);
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();

    }
    public void Resume()
    {
        inGameUI.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void Pause()
    {
        inGameUI.SetActive(false);
        pauseMenu.SetActive(true);
        if(levelMenu.activeInHierarchy)
        {
            levelMenu.SetActive(false);
        }
    }
    public void GameOver()
    {
        inGameUI.SetActive(false);
        gameOver.SetActive(true);
    }
    public void Win()
    {
        inGameUI.SetActive(false);
        winScreen.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameCompleted()
    {
        inGameUI.SetActive(false);
        completed.SetActive(true);
    }
    public void SetMonsterNo(int monsterCount)
    {
        monsterNo.text = monsterCount.ToString();
    }
    public void SetSavedNo(int friendsToSave)
    {
        savedNo.text = friendsToSave.ToString();
    }
    public void SetLevelNo(int currentLevel)
    {
        levelNo.text=currentLevel.ToString();
    }
    public void LevelSelect(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        
    }
    public void ShowLevel(bool isOnPauseMenu)
    {
        if(isOnPauseMenu)
        {
            backButton.SetActive(true);
            levelMenu.GetComponent<Image>().color=new Vector4(0,0,0,.9f);
        }
        pauseMenu.SetActive(false);
        levelMenu.SetActive(true);
    }

}
