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
    public ParticleSystem explosion;

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

            if (!boostEffect.gameObject.activeSelf)
                AudioController.Play("Lightspeed");

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
            AudioController.Stop("Lightspeed");

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
        if (col.CompareTag("Asteroid"))
        {
            AudioController.Play("Explosion");
            UnityStandardAssets.Cameras.FreeLookCam.instance.enabled = false;
            explosion.transform.parent = null;
            explosion.Simulate(0);
            explosion.Play();
            Invoke("LoadScene", 2);

            nave.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Bound2"))
        {
            UnityStandardAssets.Cameras.FreeLookCam.instance.enabled = false;

            explosion.transform.parent = null;
            explosion.Simulate(0);
            explosion.Play();
            Invoke("LoadScene", 2);

            nave.gameObject.SetActive(false);
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
