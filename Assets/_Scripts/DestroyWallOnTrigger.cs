using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWallOnTrigger : MonoBehaviour
{

    public GameObject pSystem;

    public LayerMask canDestroyMe;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    pSystem = GetComponentInChildren<ParticleSystem>();

    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer + " " + canDestroyMe.Contains(collision.gameObject.layer));
        if (canDestroyMe.Contains(collision.gameObject.layer))
        {
            EffectFactory.instance.InstantiateEffectAt(pSystem, (Vector2)transform.position + Vector2.up * 1.2f, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
public static class UnityExtensions
{

    /// <summary>
    /// Extension method to check if a layer is in a layermask
    /// </summary>
    /// <param name="mask"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
    public static bool Contains(this LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
