﻿using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
    public float life = 4;
    public ParticleSystem explosion;
    public ParticleSystem flame;

    void Start()
    {
       // Invoke("Explode",5);
        life = Random.Range(3, 5);
        if (Random.RandomRange(0, 20) == 1)
        {
            life = 10;
        }
        transform.localScale = new Vector3(life, life, life)*10;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Bound1"))
        {
            this.GetComponent<Rigidbody>().velocity = -this.GetComponent<Rigidbody>().velocity;           
        }
    }

    public void DecreaseLife()
    {
        life--;
        if (life <= 0)
        {
            Score.instance.IncreaseScore();
            Explode();
        }
    }

    void Explode()
    {
        if (AsteroidManagerSphere.instance != null)
            AsteroidManagerSphere.instance.asteroids.Remove(this.gameObject);
        AudioController.Play("Explosion");
        RadarManager.instance.asteroids.Remove(this.transform);
        explosion.transform.parent = null;
        explosion.Simulate(0);
        explosion.Play();
        Destroy(this.gameObject);
    }

    void Update()
    {
        if (Vector3.Distance(Movement.instance.pivot.transform.position, transform.position) >= 1200)
        {
            Explode();
        }
    }
}
