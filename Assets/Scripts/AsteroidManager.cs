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



        GameObject go = GameObject.Instantiate(asteroid, transform.position, Quaternion.identity) as GameObject;

        go.transform.parent = this.transform;
        go.transform.localPosition = new Vector3(Random.Range(-asteroidArea.x, asteroidArea.x),
                                                 Random.Range(-asteroidArea.y, asteroidArea.y),0);
        go.transform.parent = null;


        Vector3 playerDirection = player.transform.position - go.transform.position ;
        go.GetComponent<Rigidbody>().AddForce((playerDirection.normalized * force )+ (Random.insideUnitSphere) * speed, ForceMode.Impulse);
    }
}
