using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Joystick joystick;

    public Vector2 speed = new Vector2(50, 50);
    
    //For Audio
    //public AudioSource PlayerAudio;

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        float inputXJ = joystick.Horizontal;
        float inputYJ = joystick.Vertical;


        Vector3 movementum = new Vector3(speed.x * inputXJ, speed.y * inputYJ);

        movementum *= Time.deltaTime;

        transform.Translate(movementum);

        /**  For PC
        bool fire = Input.GetButtonDown("Fire1");

        if (fire)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if(weapon != null)
            {
                weapon.Attack(false);
                PlayerAudio.Play();
            }
        }
    **/

        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.1f, dist)).y; //0
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.9f, dist)).y;  //1

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
            Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
            transform.position.z
            );
    }

    public void AndroidShootBtn()
    {
        WeaponScript weapon = GetComponent<WeaponScript>();
        if (weapon != null)
        {
            weapon.Attack(false);
           // PlayerAudio.Play();
        }
    }




}
