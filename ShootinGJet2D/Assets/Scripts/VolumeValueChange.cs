using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeValueChange : MonoBehaviour
{
    public AudioSource mainAudio;
    private float muxicVolume = 1f;

    public Text HighScoreText;

    // Start is called before the first frame update
    void Start()
    {
        HighScoreText.text = PlayerPrefs.GetInt("SCORE").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        mainAudio.volume = muxicVolume;
        
    }

    public void ChangeVolume(float vol)
    {
        muxicVolume = vol;
    }
}
