using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("LastLevelCleared"))
        {
            //do noothinng
        }
        else
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

    public void LevelCleared()
    {
        int previousSceneBuildIndex = PlayerPrefs.GetInt("LastLevelCleared");
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        int levelCount = PlayerPrefs.GetInt("LevelClearedCount");


        if(currentSceneBuildIndex > previousSceneBuildIndex)
        {
            PlayerPrefs.SetInt("LastLevelCleared", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("LevelClearedCount", levelCount + 1);
            print(" Total No of Level Cleared Are" + PlayerPrefs.GetInt("LevelClearedCount"));


            //TODO:   Again Set Values to above variables
            
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
