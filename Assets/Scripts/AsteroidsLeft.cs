using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AsteroidsLeft : MonoBehaviour
{
    public static AsteroidsLeft instance;

    public Text asteroidsLeft;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        asteroidsLeft.text = string.Format("{0} asteroids left", AsteroidManagerSphere.instance.asteroids.Count);

    }
}
