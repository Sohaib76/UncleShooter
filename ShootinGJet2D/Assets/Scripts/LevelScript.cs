using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public AudioSource clickAudio;
    public AudioSource hoverAudio;

    // Start is called before the first frame update
    void Start()
    {
        disableAllBtns();

        if (!PlayerPrefs.HasKey("LastLevelCleared"))
        {
            PlayerPrefs.SetInt("LastLevelCleared", 0);
        }
      

        //try USe Levels.LevelCleared().levelCount;   and apply for loop on it
        int clearedLevels = PlayerPrefs.GetInt("LevelClearedCount");
        for (int i=0; i<clearedLevels+1; ++i)
        {
            transform.GetChild(i).GetComponent<Button>().interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void disableAllBtns()
    {
        int allBtnCount = transform.childCount;

        for (int i = 0; i < allBtnCount; ++i) //try i++
        {
            transform.GetChild(i).GetComponent<Button>().interactable = false;
        }
        
    }

    //CCCCCCCheck
    public void playLevel()
    {
        SceneManager.LoadScene("Level1R");
    }

    public void playLevel2()
    {
        SceneManager.LoadScene("Level2R");
    }

    public void playLeve3()
    {
        SceneManager.LoadScene("Level3R");
    }

    public void playLevel4()
    {
        SceneManager.LoadScene("Level4R");
    }

    public void playLevel5()
    {
        SceneManager.LoadScene("Level5");
    }

    public void playLevel6()
    {
        SceneManager.LoadScene("Level6");
    }

    public void ClickAudio()
    {
        clickAudio.Play();
    }

    public void HoverAudio()
    {
        hoverAudio.Play();
    }

}
