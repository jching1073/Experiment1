using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    [SerializeField] private GameObject bulletToFire;
    [SerializeField] Transform firePoint;
    [SerializeField] private float timeBetweenShot;
    private float shotsFired;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire");
            Shoot();
        }
        if (Input.GetButton("Fire1"))
        {
            shotsFired = shotsFired - Time.deltaTime;
            if(shotsFired <= 0)
            {
                Shoot();
                shotsFired = timeBetweenShot;
            }

        }
    }
    void Shoot()
    {
        Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
       // if(Input.get)
    }
    
}
