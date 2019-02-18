using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EffectsController : MonoBehaviour
{


    public static EffectsController instance;

    public ParticleSystem smokeEffects;
    public ParticleSystem fireEffects;

    public AudioSource ExplosionSound;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Multiple Instances Of Effects");
        }

        instance = this;
    }

    public void Explosion(Vector3 position)
    {
        instantiate(smokeEffects, position);
        instantiate(fireEffects, position);
    }

   private ParticleSystem instantiate (ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem particleSystem = Instantiate(prefab, position, Quaternion.identity) as ParticleSystem;

        Destroy(particleSystem.gameObject, particleSystem.startLifetime);
        return particleSystem;
        
    }

    public void explosionSound()
    {
        ExplosionSound.Play();
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
