using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 speedTravel;
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

    public void LoadAttributesAndShoot(Vector2 bulletSpeed)
    {
        rbBullet = GetComponent<Rigidbody2D>();

        this.speedTravel = bulletSpeed;
        var rforc = Vector2.one * speedTravel;
        rbBullet.AddForce(rforc, ForceMode2D.Impulse);
    }
}
