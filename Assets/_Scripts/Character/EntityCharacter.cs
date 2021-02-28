using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCharacter : MonoBehaviour
{
    protected Rigidbody2D rbCharacter;
    protected BoxCollider2D boxCollider2d;
    protected SpriteRenderer spRend;
    protected Health healthSys;


    // Start is called before the first frame update
    public virtual void Awake()
    {
        rbCharacter = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        spRend = GetComponentInChildren<SpriteRenderer>();
        healthSys = GetComponent<Health>();
    }

    protected void FlipSprite(float xDirectionMove)
    {
        Vector2 scaleOriginal = spRend.transform.localScale;

        if (xDirectionMove < 0)
        {
            scaleOriginal.x = Mathf.Abs(scaleOriginal.x) * -1;
        }
        else
        {
            scaleOriginal.x = Mathf.Abs(scaleOriginal.x);
        }

        spRend.transform.localScale = scaleOriginal;

    }
}
