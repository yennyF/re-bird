using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float velocity = 1;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public Sprite flying, falling, dying;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isFlying", false);

        if (Input.GetMouseButtonDown(0)) // Left click
        {
            // Jump
            //spriteRenderer.sprite = flying;
            animator.Play("BirdAnimation");

            rb.velocity = Vector2.up * velocity;
            //animator.SetBool("isFlying", true);
            //Debug.Log(rb.velocity);
        }

        if (rb.velocity.y < 0)
        {
            
            //spriteRenderer.sprite = falling;
        }
    }
}
