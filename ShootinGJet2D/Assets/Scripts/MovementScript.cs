using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    public Vector2 speed = new Vector2(50, 50);
    public Vector2 direction = new Vector2(-1, 0);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementum = new Vector3(speed.x * direction.x, speed.y * direction.y);

        movementum *= Time.deltaTime;

        transform.Translate(movementum);
    }
}
