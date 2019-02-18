using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTrack : MonoBehaviour
{

    int score = 0;
   

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("SCORE", 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    //Now Useless
    public static void addScore(int score = 0)
    {
       

        score++;
        PlayerPrefs.SetInt("SCORE", score);
        // scoreText.text = score.ToString();
        print("Score is" + score);
        
    }
}
