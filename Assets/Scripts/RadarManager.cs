using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RadarManager : MonoBehaviour {
    public static RadarManager instance;
    public float maxDistance = 500;
    public List<Transform> asteroids;
    public List<Image> asteroidsPoint;
    public Image radarBackground;
    // Use this for initialization
    void Awake()
    {
        instance = this;
    }
	
    // Update is called once per frame
	void Update ()
    {
        Debug.Log(Movement.instance.nave.transform.root.transform.localEulerAngles.y);
        radarBackground.rectTransform.localRotation = Quaternion.Euler(0, 0, Movement.instance.nave.transform.root.transform.localEulerAngles.y);
        for (int i =0; i < asteroids.Count; i++)
        {
            asteroidsPoint[i].rectTransform.anchoredPosition = CheckDistanceOnRadar(asteroids[i]);
        }
	}

    Vector2 CheckDistanceOnRadar(Transform t)
    {
        Vector3 v1 = t.position;
        Vector3 v2 = Movement.instance.nave.transform.position;
        v1.y = 0;
        v2.y = 0;
        float distance = Vector3.Distance(v1, v2);
        Vector3 direction = v1 - v2;
        return new Vector2(direction.normalized.x * distance / maxDistance * 45, direction.normalized.z * distance / maxDistance * 45);
    }
}
