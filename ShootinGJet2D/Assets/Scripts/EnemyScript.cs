using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private WeaponScript weapon;

    public AudioSource EnemyAudio;
    private void Awake()
    {
        Destroy(gameObject, 30);
        weapon = GetComponent<WeaponScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(weapon != null && weapon.CanAttack)
        {
            weapon.Attack(true);
            EnemyAudio.Play();
        }

        if (PlayerHealth.isLevelComple == true)
        {
            EffectsController.instance.Explosion(transform.position);
            EffectsController.instance.explosionSound();
            Destroy(this.gameObject);
        }
    }
}
