using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strt : MonoBehaviour
{
    public float sec = 10f;
    public GameObject objectt;
    public GameObject objectt1;
    public AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        aud.Play();
        StartCoroutine(LateCall());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LateCall()
    {

        yield return new WaitForSeconds(sec);
        print(Time.time);

        objectt.SetActive(true);
        objectt1.SetActive(true);
        Destroy(gameObject);
        //Do Function here...
    }
}
