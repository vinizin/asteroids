using UnityEngine;
using System.Collections;

public class AsteroidManager : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject player;
    public Vector3 asteroidArea;
    public float asteroidDelay = 0.1f;
    public int initialNumber = 10;
    private float asteroidDelayAux;
    public float speed;
    public float force;
    public float torqueForce;

    void Start()
    {
        for(int i = 0; i < initialNumber; i++)
        {
            CreateAsteroid();
        }
    }

    void Update()
    {
        if (asteroidDelayAux <= 0)
        {
            CreateAsteroid();
            asteroidDelayAux = asteroidDelay;
        }
        asteroidDelayAux -= Time.deltaTime;
    }

    private void CreateAsteroid()
    {
        if (RadarManager.instance.asteroids.Count >= 20) return;

        GameObject go = GameObject.Instantiate(asteroid, transform.position, Quaternion.identity) as GameObject;

        RadarManager.instance.asteroids.Add(go.transform);

        go.transform.parent = this.transform;
        go.transform.localPosition = new Vector3(Random.Range(-asteroidArea.x, asteroidArea.x),
                                                 Random.Range(-asteroidArea.y, asteroidArea.y),0);
        go.transform.parent = null;


        Vector3 playerDirection = player.transform.position - go.transform.position ;
        float maxVelocity = force * 3;
        float velocity = Random.Range(force / 4, force * Mathf.Clamp((Score.instance.currentScore / 2.0f), 1, 2));
        if (0.5f * maxVelocity <= velocity)
        {
            go.GetComponent<Asteroid>().flame.gameObject.SetActive(true);
            velocity *= 2;
        }
        go.GetComponent<Rigidbody>().AddForce((playerDirection.normalized * velocity  + (Random.insideUnitSphere) * speed), ForceMode.Impulse);
        go.GetComponent<Rigidbody>().AddTorque(Random.insideUnitSphere * torqueForce);
    }
}
