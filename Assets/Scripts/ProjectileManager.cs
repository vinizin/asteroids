using UnityEngine;
using System.Collections;

public class ProjectileManager : MonoBehaviour
{
    public GameObject projectile;
    public GameObject pivot;
    public GameObject projectileLocator;
    public float speedforce = 6.0f;
    public float shootDelay = 0.1f;
    private float shootDelayAux = 0.1f;
    public bool canShoot = true;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && shootDelayAux <= 0 && canShoot)
        {
            Shoot();
            shootDelayAux = shootDelay;
        }
        shootDelayAux -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject go = Instantiate(projectile, projectileLocator.transform.position, projectileLocator.transform.rotation) as GameObject;
        AudioController.Play("Laser");
        go.GetComponent<Rigidbody>().AddForce(pivot.transform.forward * speedforce, ForceMode.Impulse);
        
    }
}
