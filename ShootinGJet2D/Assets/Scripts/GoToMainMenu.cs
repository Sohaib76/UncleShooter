using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("LastLevelCleared"))
        {
            PlayerPrefs.SetInt("LastLevelCleared", 0);
        }
        if (PlayerPrefs.HasKey("LevelClearedCount"))
        {
            //do no
        }
        else
        {
            PlayerPrefs.SetInt("LevelClearedCount", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevelStart()
    {
        int previousSceneBuildIndex = PlayerPrefs.GetInt("LastLevelCleared");
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        int levelCount = PlayerPrefs.GetInt("LevelClearedCount");


        if (currentSceneBuildIndex > previousSceneBuildIndex)
        {
            PlayerPrefs.SetInt("LastLevelCleared", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("LevelClearedCount", levelCount + 1);
            print(" Total No of Level Cleared Are" + PlayerPrefs.GetInt("LevelClearedCount"));


            //TODO:   Again Set Values to above variables

        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void backLevelSelectScreen()
    {
        SceneManager.LoadScene("LevelSelect");
    }



    public void StartScreenLoad()
    {
        SceneManager.LoadScene("StartScreen");
    }


    public void MainMenuLoad()
    {
        int previousSceneBuildIndex = PlayerPrefs.GetInt("LastLevelCleared");
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        int levelCount = PlayerPrefs.GetInt("LevelClearedCount");


        if (currentSceneBuildIndex > previousSceneBuildIndex)
        {
            PlayerPrefs.SetInt("LastLevelCleared", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("LevelClearedCount", levelCount + 1);
            print(" Total No of Level Cleared Are" + PlayerPrefs.GetInt("LevelClearedCount"));


            //TODO:   Again Set Values to above variables
           
        }
       
        else
        {
            print("Current Build Index " + currentSceneBuildIndex + "is not greater than " + "Previous Build Index"+previousSceneBuildIndex);
        }
        SceneManager.LoadScene("LevelSelect");
    }

    public void ReloadScene()
    {
        PlayerHealth.isLevelComple = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
