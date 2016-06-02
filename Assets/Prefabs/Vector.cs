using UnityEngine;
using System.Collections;

public class Vector : MonoBehaviour {
    public Vector3 aux;
    public Vector3[] normals;
    // Use this for initialization
    void Start ()
    {
        foreach (Vector3 v in normals)
            Debug.Log(Vector3.Angle(aux, v));


        foreach (Vector3 v in normals)
            Debug.Log(Vector3.ProjectOnPlane(aux,v));

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
