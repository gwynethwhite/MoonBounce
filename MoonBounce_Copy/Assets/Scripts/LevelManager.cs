using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public int levelNum;
    private bool paused;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject winPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerStats.AllLevelsCompleted()){
            PlayerStats.Clear();
        }
        levelNum = PlayerStats.GetNextLevel();
        pausePanel.SetActive(false);
        winPanel.SetActive(false);
        paused = false;
        if (levelNum == -1)
        {
            EndLevel();
        }

    }

    public void EndLevel(){
        PlayerStats.SetLevelCompleted(levelNum);
        Time.timeScale = 0.5f;
        winPanel.SetActive(true);
        Invoke("SwitchScene", 1.5f);
    }

    public void SwitchScene(){
        Debug.Log("SwitchScene triggered");
        SceneManager.LoadScene(2);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }

    //triggers pause or unpause
    public void TriggerPauseMenu()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
