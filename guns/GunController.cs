using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    // Start is called before the first frame update
    private float timeSinceLastShot = 0;
    private bool readyToFire = false;
    public float fireRate; // per second
    public GameObject bullet;
    public virtual void Start()
    {
        fireRate = 1;
        timeSinceLastShot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= 1/fireRate)
        {
            readyToFire = true;
        }
    }

    public bool isReady()
    {
        return readyToFire;
    }

    public void Fire(Vector3 target)
    {
        float angle = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
        // create a projectile and set its position to the player's position and set its rotation to the angle
        GameObject projectile = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg)) as GameObject;
        readyToFire = false;
        timeSinceLastShot = 0;
    }

}
