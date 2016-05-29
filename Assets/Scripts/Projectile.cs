using UnityEngine;
using System.Collections;
using System;

public class Projectile : MonoBehaviour {
    public int timeToDestroy = 2;
    public ParticleSystem[] ps;

    void Start()
    {
        Invoke("DestroyThis", timeToDestroy);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Asteroid"))
        {
            col.gameObject.GetComponent<Asteroid>().DecreaseLife();
            DestroyThis();
        }
       // Destroy(this.gameObject);
    }

    void DestroyThis()
    {
        foreach (ParticleSystem s in ps)
        {
            s.transform.parent = null;
            s.Simulate(0);
            s.Play();
        }

        Destroy(this.gameObject);
    }
}
