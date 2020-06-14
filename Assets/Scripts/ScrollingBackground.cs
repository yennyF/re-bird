/*
    author: nisa
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private float groundWidth;
    [SerializeField]
    private float scrollSpeed;
    
    void Awake()
    {
        groundWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // void Start()
    // {
    //     rb2d = GetComponent<Rigidbody2D>();
    //     rb2d.velocity = new Vector2(scrollSpeed, 0);
    // }

    private void Update()
    {
        // if(GameControl.instance.gameOver == true)
        // {
        //     rb2d.velocity = Vector2.zero;
        // }

        // transform.position = new Vector2(transform.position.x + (scrollSpeed * Time.deltaTime), transform.position.y);

        transform.position = new Vector2(
            transform.position.x + (scrollSpeed * Time.deltaTime), 
            transform.position.y
        );

        if (transform.position.x < -groundWidth)
        {
            RepositionBackground ();
        }
    }

    private void RepositionBackground()
    {
        Vector2 groundOffSet = new Vector2(groundWidth * 2f, 0);
        transform.position = (Vector2) transform.position + groundOffSet;
    }
}
