using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemySpawner : MonoBehaviour
{

    public GameObject anEnemy;
    float rand;
    Vector2 spawnPosition;
    public float spawnRate;
    public float nextSpawn = 5f;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerHealth.isLevelComple != true)
        {
            print("Level Complete is "+ PlayerHealth.isLevelComple);
            InvokeRepeating("SpawnEnemy", nextSpawn, spawnRate);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
        /**
     
           if (Time.time > nextSpawn)
            {
                // nextSpawn = Time.time * spawnRate;
                nextSpawn += 5f;
                float posx = transform.position.x;
                rand = Random.Range(posx, 8.3f);
                spawnPosition = new Vector2(rand, transform.position.y);

                Instantiate(anEnemy, spawnPosition, Quaternion.identity);
            }
       
       **/
    }

    void SpawnEnemy()
    {
        if (PlayerHealth.isLevelComple == false)
        {
            float posx = transform.position.x;
            rand = Random.Range(posx, 8.3f);
            spawnPosition = new Vector2(rand, transform.position.y);
            Instantiate(anEnemy, spawnPosition, Quaternion.identity);
        }
        
    }

}
