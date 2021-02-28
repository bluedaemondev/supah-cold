using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speedTravel = 200;
    Rigidbody2D rbBullet;

    public GameObject impactPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(impactPrefab != null)
        {
            EffectFactory.instance.InstantiateEffectAt(impactPrefab, collision.GetContact(0).point, Quaternion.identity);
        }
        Destroy(this.gameObject);
    }

    public void LoadAttributesAndShoot(float bulletSpeed)
    {
        rbBullet = GetComponent<Rigidbody2D>();

        this.speedTravel = bulletSpeed;
        rbBullet.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
    }
}
