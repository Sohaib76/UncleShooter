using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource mainMenuAudio;
    public AudioSource hoverAudio;
    

    public void MainMenuAudio()
    {
        mainMenuAudio.Play();
        
        print("Played Audio");
    }


    public void HoverAudio()
    {
        hoverAudio.Play();

        print("Played Audio");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
