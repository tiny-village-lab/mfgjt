using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public Animator animator;
    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        animator.SetFloat("Walkspeed", Mathf.Abs(rigidbody.velocity.x));
        if(rigidbody.velocity.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        if(rigidbody.velocity.x < 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
