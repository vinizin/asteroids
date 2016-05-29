using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class Movement : MonoBehaviour
{
    public static Movement instance;
    public Rigidbody rbd;
    public GameObject pivot;
    public GameObject nave;
    public float speed;
    public ParticleSystem boostEffect;
    public Animator anim;
    public ProjectileManager pm;
    public float deltaDistance = 0;
    private Vector3 lastPosition;

    void Start()
    {
        instance = this;
    }
    void Update()
    {

        deltaDistance += Vector3.Distance(transform.position,lastPosition);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Boost", true);
            boostEffect.gameObject.SetActive(true);

            if (!boostEffect.isPlaying)
            {
                pm.canShoot = false;
                boostEffect.Play();
            }
            rbd.velocity = pivot.transform.forward * speed * 5;
        }
        else
        {
            if (boostEffect.isPlaying)
            {
                pm.canShoot = true;
                boostEffect.Stop();
                boostEffect.gameObject.SetActive(false);
            }
            anim.SetBool("Boost", false);

            rbd.velocity = pivot.transform.forward * speed;
        }


        lastPosition = transform.position;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Asteroid") || col.CompareTag("Bound"))
        {
            Invoke("LoadScene",2);

            nave.gameObject.SetActive(false);
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
