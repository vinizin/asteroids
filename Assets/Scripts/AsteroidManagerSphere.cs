using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidManagerSphere : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject sphere;
    public GameObject player;
    public Vector3 asteroidArea;
    public float asteroidDelay = 0.1f;
    public int initialNumber = 10;
    private float asteroidDelayAux;
    public float speed;
    public bool isInGame = false;
    public float force;
    public float torqueForce;
    public List<GameObject> asteroids;
    public int level;
    public static AsteroidManagerSphere instance;

    void Start()
    {
       
        instance = this;
        for(int i = 0; i < initialNumber; i++)
        {
            CreateAsteroid();
        }
        isInGame = true;
    }

    void Update()
    {
        if (isInGame && asteroids.Count == 0)
        {
            if (Level.instance != null)
            {
                Level.instance.IncreaseLevel();
            }
            level++;
            isInGame = false;
            initialNumber = (int) (initialNumber * 1.2f);
            Mathf.Clamp(initialNumber, 0, 20);
            Start();
        }
    }

    private void CreateAsteroid()
    {
        if (RadarManager.instance.asteroids.Count >= 20) return;

        GameObject go = GameObject.Instantiate(asteroid, transform.position, Quaternion.identity) as GameObject;
        asteroids.Add(go);
        RadarManager.instance.asteroids.Add(go.transform);

        do
        {
            go.transform.position = sphere.transform.position + Random.insideUnitSphere * Random.Range(0, sphere.GetComponent<SphereCollider>().radius);
        }
        while (Vector3.Distance(go.transform.position, player.transform.position) <= 100);

        Vector3 playerDirection = player.transform.position - go.transform.position ;
        go.GetComponent<Rigidbody>().AddForce((Random.insideUnitSphere * Random.Range(force/4, force) )+ (Random.insideUnitSphere) * speed, ForceMode.Impulse);
        go.GetComponent<Rigidbody>().AddTorque(Random.insideUnitSphere * torqueForce);
    }


}
