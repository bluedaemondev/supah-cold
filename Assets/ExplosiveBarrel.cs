using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public float radiusExplosion = 1.5f;
    public float forceApply = 8f;

    public GameObject particlesExplosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.GetComponent<Bullet>())
        {
            var cast = Physics2D.CircleCastAll(transform.position, radiusExplosion, Vector2.zero);
            if (cast.Length != 0)
            {

                foreach (var item in cast)
                {
                    if (item.collider.CompareTag("Player"))
                    {
                        Debug.Log("HIJO DE MIL PUTA");
                        item.collider.GetComponent<Rigidbody2D>().AddForce((item.collider.transform.position - transform.position).normalized * forceApply, ForceMode2D.Impulse);
                    }
                    else if(item.collider.GetComponent<Health>())
                    {
                        item.collider.GetComponent<Health>().Damage(item.collider.GetComponent<Health>().GetMaxLife());
                    }
                }
            }
            EffectFactory.instance.InstantiateEffectAt(particlesExplosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
