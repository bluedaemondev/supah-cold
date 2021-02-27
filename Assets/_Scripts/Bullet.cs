using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speedTravel = 200;
    Rigidbody2D rbBullet;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.GetComponent<Health>() != null)
        //{
            
        //    //HealthSystem hlth = collision.gameObject.GetComponent<Entity>().health;
        //    //hlth.Damage(hlth.GetMaxLife());
        //}
    }

    public void LoadAttributesAndShoot(float bulletSpeed)
    {
        rbBullet = GetComponent<Rigidbody2D>();

        this.speedTravel = bulletSpeed;
        rbBullet.AddForce(transform.forward * bulletSpeed, ForceMode2D.Impulse);
    }
}
