using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject bg;

    private Collider2D collider2D;

    public GameObject Boss;

    public AudioSource healthPUAudio;

    public AudioSource levelCompletedAudio;
    public AudioSource gameOverAudio;
    public GameObject gameSound;

    public Text Scoree;

    public GameObject HealthBar;
    private Transform bar;

    //int score = 0;

    public int hp = 2;
    public bool isEnemy = true;
   
    public static bool isLevelComple = false;

    public GameObject restartPanel;

    public GameObject levelCompleted;



    private void Start()
    {
        isLevelComple = false;


        WeaponScript.canFire = true;


        collider2D = GetComponent<BoxCollider2D>();

        bar = HealthBar.transform.Find("Bar");
        

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




    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collide");
        BulletShotScript shot = collision.gameObject.GetComponent<BulletShotScript>();

    
        if (shot != null)
        {
            if(shot.isEnemyShot != isEnemy)
            {
                hp -= shot.damage;
                //score++;
                //print("Score is " + score);
                Destroy(shot.gameObject);
                if (hp == 2)
                {
                    bar.localScale = new Vector3(.7f, 1f);
                }
                    if (hp == 1)
                {
                    bar.localScale = new Vector3(.4f, 1f);
                   
                    

                    
                }
                else if(hp <= 0)
                {
                    EffectsController.instance.Explosion(transform.position);
                    EffectsController.instance.explosionSound();
                   
                    ActiveRestartPanel();

                }
              
            }
        }

        else if(collision.gameObject.tag == "PUHealthFull")
        {
            hp = 3;
            bar.localScale = new Vector3(1f, 1f);
            healthPUAudio.Play();
            Destroy(collision.gameObject);
        }

       
        else if (collision.gameObject.tag == "IncreaseFireSpeed")
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            weapon.shootingRate = 0.25f;
            healthPUAudio.Play();
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag == "PUDark")
        {
            SpriteRenderer renderer = this.GetComponentInChildren<SpriteRenderer>();
            renderer.color = new Color(0f, 0f, 0f, 1f); // Set to opaque black

            collider2D.isTrigger = true;
            healthPUAudio.Play();
            Destroy(collision.gameObject);
        }


        else if(collision.gameObject.tag == "nextLevelWall")
        {
            LevelCompletedDialog();

            int s = Health.scr;
            print(s);
            int previousScore = PlayerPrefs.GetInt("SCORE");
            PlayerPrefs.SetInt("SCORE", previousScore+s);
            Scoree.text = PlayerPrefs.GetInt("SCORE").ToString();

            /**
            print("Total Score is" + Health.scr);
            if (Health.scr >= 10)
            {
                Scoree.text = Health.scr.ToString();
            }
            else
            {
                Scoree.text = "0" + Health.scr.ToString();
            }
            **/
            

            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (collision.gameObject.tag == "BossComing")
        {
            Boss.SetActive(true);
        }

        else if (collision.gameObject.tag == "EnvironmentChange")
        {
            SpriteRenderer xx = bg.GetComponent<SpriteRenderer>();
            xx.color = Color.gray;
            WeaponScript.canFire = false;

           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    public void LevelCompletedDialog()
    {
        isLevelComple = true;
        levelCompletedAudio.Play();
        gameSound.SetActive(false);
        print("Level Completiis True");
        levelCompleted.SetActive(true);
    }

    public void LevelCleared()
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
        isLevelComple = false;
    }



    public void activeRestartPanel()
    {
        restartPanel.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isLevelComple == false)
        {
            if (collision.gameObject.tag == "enemy")
            {
                EffectsController.instance.Explosion(transform.position);
                EffectsController.instance.explosionSound();
                ActiveRestartPanel();
               

            }
        }
       
    }

    public void ActiveRestartPanel()
    {
        Destroy(gameObject);
        gameSound.SetActive(false);
        levelCompletedAudio.Stop();
        gameOverAudio.Play();
        activeRestartPanel();
    }
}
