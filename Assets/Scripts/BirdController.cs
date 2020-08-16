using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private AudioManager audioManager;
    public float upForce = 200f;
    // public float velocity = 1;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isDead = false;
    [System.NonSerialized] public bool isHappy = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioManager = AudioManager.instance;
    }

    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0)) // Left click | Jump
            {
                // rb.velocity = Vector2.up * velocity;
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, upForce));

                animator.SetTrigger("Flap");

                audioManager.Play("Flap");
            }

            if (isHappy == true)
            {
                animator.Play("Happy");
                isHappy = false;
            }
        }
    }

    void OnCollisionEnter2D()
    {
        isDead = true;
        animator.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }

}
