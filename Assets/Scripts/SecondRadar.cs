using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SecondRadar : MonoBehaviour
{
    public LineRenderer lr;
    public Transform refObj;
    public List<GameObject> objsInRadar;
    void Awake()
    {
        this.transform.parent = null;
    }

    void Update()
    {
        this.transform.position = refObj.position;
        int i = 0;
        lr.SetVertexCount(objsInRadar.Count * 2);
        foreach (GameObject go in objsInRadar)
        {
            lr.SetPosition(i, refObj.transform.position);
            i++;
            lr.SetPosition(i,go.transform.position);
            i++;
        }
    }
}
