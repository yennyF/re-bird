/*
    author: nisa
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    // private Rigidbody2D rb2d;
    private float width;
    [ SerializeField ]
    private float scrollSpeed = 0;
    
    void Awake()
    {
        width = GetComponent< SpriteRenderer >().bounds.size.x;
    }

    // void Start()
    // {
    //     rb2d = GetComponent< Rigidbody2D >();
    //     rb2d.velocity = new Vector2( scrollSpeed, 0 );
    // }

    private void Update()
    {
        if( GameControl.instance.gameOver == false )
        {
            transform.position = new Vector2(
                transform.position.x + ( scrollSpeed * Time.deltaTime ), 
                transform.position.y
            );
            // rb2d.velocity = Vector2.zero;

            if ( transform.position.x < -width )
            {
                RepositionBackground ();
            }
        }
    }

    private void RepositionBackground()
    {
        Vector2 offSet = new Vector2( width * 2f, 0 );
        transform.position = ( Vector2 ) transform.position + offSet;
    }
}
