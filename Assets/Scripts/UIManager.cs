using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu,pauseMenu,inGameUI,gameOver,winScreen,completed;
    [SerializeField] TextMeshProUGUI monsterNo,savedNo,levelNo;

    public void Play()
    {
        int currentLevelIndex=PlayerPrefs.GetInt("CurrentLevel");
        if(currentLevelIndex==0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(currentLevelIndex);
        }
        
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
    void Pause()
    {
        inGameUI.SetActive(false);
        pauseMenu.SetActive(true);
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
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !mainMenu.activeInHierarchy)
        {
            Pause();
        }
    }

}
