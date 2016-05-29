using UnityEngine;
using System.Collections;

public class DestroyAfterPlay : MonoBehaviour {
    ParticleSystem ps;
    bool canDestroy = false;
	// Use this for initialization
	void Start () {
        ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (ps.isPlaying)
            canDestroy = true;
        if (!ps.isPlaying && canDestroy)
            Destroy(this.gameObject);
	}
}
