using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int hp = 2;
    public bool isEnemy = true;
    public int value = 1;

    //  int score = 0;

  // public static int scr = 0;

    public static int scr = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collide");
        BulletShotScript shot = collision.gameObject.GetComponent<BulletShotScript>();

        if(shot != null)
        {
            if(shot.isEnemyShot != isEnemy)
            {
                hp -= shot.damage;
                print("Enemy Health is " + hp);

                Destroy(shot.gameObject);
                if(hp <= 0)
                {
                    if(value == 1)
                    {
                        scr += 1;
                    }
                    if (value == 2)
                    {
                        scr += 5;
                    }
                    if (value == 3)
                    {
                        scr += 10;
                    }


                    //scr++;
                    //ScoreTrack.addScore(scr);
                    //print(scr);
                    // PlayerPrefs.SetInt("SCORE",scr++);



                    EffectsController.instance.Explosion(transform.position);
                    EffectsController.instance.explosionSound();
                    Destroy(gameObject);
                }

               
            }
        }

        




    }
    

}
