using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Health>())
        {
            var health = collision.gameObject.GetComponent<Health>();

            health.Damage(health.GetMaxLife());
            collision.gameObject.GetComponent<Rigidbody2D>()
                .AddForceAtPosition(((Vector2)collision.otherCollider.transform.position - collision.GetContact(0).point) * 10f, collision.GetContact(0).point);
        }
    }
}
