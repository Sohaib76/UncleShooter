using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShotScript : MonoBehaviour
{
    public int damage = 1;
    public bool isEnemyShot = false;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
