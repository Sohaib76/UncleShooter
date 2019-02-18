using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public static bool canFire = true;

    public Transform shotPrefab;
    public float shootingRate = 0.5f;
    public float shootingCoolDown;

    private AudioSource testAud;

    // Start is called before the first frame update
    void Start()
    {

        testAud = GetComponent<AudioSource>();
        shootingCoolDown = 0f;   
    }

    // Update is called once per frame
    void Update()
    {
        if(shootingCoolDown > 0)
        {
            shootingCoolDown -= Time.deltaTime;
        }

    }

    public void Attack(bool isEnemy)
    {
        if (CanAttack && canFire)
        {
            shootingCoolDown = shootingRate;
            var shotTransform = Instantiate(shotPrefab) as Transform;
            shotTransform.position = transform.position;
            testAud.Play();
            BulletShotScript shot = shotTransform.gameObject.GetComponent<BulletShotScript>();
            if(shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }
        }

    }

    public bool CanAttack
    {
        get
            {
            return shootingCoolDown <= 0;
        }
    }
}
