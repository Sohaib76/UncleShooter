using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUHealthFull : MonoBehaviour
{

    /**
    public GameObject healthFull;
    public GameObject increaseFireRate;

    float rand;
    Vector2 spawnPosition;
    public float spawnRate;
    public float spawnRate2;
    public float nextSpawn = 5f;
    public float nextSpawn2 = 5f;
    **/


    // Start is called before the first frame update
    void Start()
    {
        /**
        if (PlayerHealth.isLevelComple != true)
        {
            print("Level Complete is " + PlayerHealth.isLevelComple);
            InvokeRepeating("SpawnPowerUp", nextSpawn, spawnRate);
            InvokeRepeating("SpawnFireUp", nextSpawn2, spawnRate2);
        }**/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /**
    void SpawnPowerUp()
    {
        if (PlayerHealth.isLevelComple == false)
        {
            float posx = transform.position.x;
            rand = Random.Range(posx, 8.3f);
            spawnPosition = new Vector2(rand, transform.position.y);
            Instantiate(healthFull, spawnPosition, Quaternion.identity);
        }

    }

    void SpawnFireUp()
    {
        if (PlayerHealth.isLevelComple == false)
        {
            float posx = transform.position.x;
            rand = Random.Range(posx, 8.3f);
            spawnPosition = new Vector2(rand, transform.position.y);
            Instantiate(healthFull, spawnPosition, Quaternion.identity);
        }

    }
    **/
}
