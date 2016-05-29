using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
    public float life = 4;
    public ParticleSystem explosion;

    void Start()
    {
        life = Random.Range(3, 5);
        if (Random.RandomRange(0, 20) == 1)
        {
            life = 10;
        }
        transform.localScale = new Vector3(life, life, life)*10;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Bound"))
        {
            Destroy(this.gameObject);
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
        explosion.transform.parent = null;
        explosion.Simulate(0);
        explosion.Play();
        Destroy(this.gameObject);
    }
}
