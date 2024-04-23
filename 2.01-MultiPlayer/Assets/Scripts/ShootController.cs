using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.Netcode;
using UnityEngine;

public class ShootController : NetworkBehaviour
{
    [SerializeField] private GameObject hitParticles;

    [SerializeField] private Transform projectilePrefab;

    [SerializeField] private float nextShoot = 0f;

    [SerializeField] private float shootDelay = 0.25f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner)
            return;
        if (nextShoot > 0)
        {
            nextShoot-= Time.deltaTime;
        }

        bool shoot = Input.GetKey(KeyCode.Space);
        if(shoot && nextShoot <= 0 )
        {
           
            Shoot();
            nextShoot = shootDelay;
        }

    }

    private void Shoot()
    {


        //Prepare the Rotation of the projectile
        Quaternion rotation = Quaternion.FromToRotation(Vector3.right,transform.forward);
        //Instantiate it
        Transform projectile = Instantiate(projectilePrefab, transform.position, rotation);
        //Gives it its direction
        Vector3 shootDirection = transform.forward;
        projectile.GetComponent<Projectile>().Setup(shootDirection,gameObject);

    }
}
