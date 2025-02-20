﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    public float cooldownFireRate = 0.4f;
    public float bulletSpeed = 200f;

    public bool playerHeld = false;
    public bool equiped = false;
    public bool canShoot = true;
    public GameObject prefabShoot;


    protected Gunpoint gunpoint; // guarda de donde salen los tiros

    // Start is called before the first frame update
    public virtual void Start()
    {
        gunpoint = GetComponentInChildren<Gunpoint>();
    }

    public virtual IEnumerator Cooldown(float timeCd)
    {
        canShoot = false;
        yield return new WaitForSecondsRealtime(timeCd); //Realtime
        canShoot = true;
    }

    public virtual void StartCooldown(float timeCd)
    {
        StartCoroutine(Cooldown(timeCd));
    }

    public virtual void PickUp()
    {
        if (!equiped)
        {
            equiped = true;

        }
    }

    public virtual void Shoot()
    {
        if (canShoot)
        {
            var bullet = Instantiate(prefabShoot, gunpoint.gunpointTransform.position, transform.rotation);
            //bullet.GetComponent<Rigidbody2D>().velocity = transform.parent.parent.GetComponent<Rigidbody2D>().velocity;
            bullet.GetComponent<Bullet>().LoadAttributesAndShoot((gunpoint.transform.position - transform.position).normalized * bulletSpeed);
            StartCooldown(cooldownFireRate);
            Debug.Log("Shooting " + transform.parent.parent.name);
        }
    }

    public virtual void ThrowSelf(Vector3 direction)
    {
        if (equiped)
        {
            transform.parent = null;
            var rbGun = GetComponent<Rigidbody2D>();
            //rbGun = 
            rbGun.AddForce(transform.forward, ForceMode2D.Impulse);
            float randRotTorque = Random.Range(-1, 1);
            rbGun.AddTorque(randRotTorque * 10f);
        }
    }


}
