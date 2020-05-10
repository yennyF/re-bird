using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBacground : MonoBehaviour
{
    // private BoxCollider2D groundCollider;
    private float groundHorizontalLength;
    void Awake()
    {
        // groundCollider = GetComponent<BoxCollider2D> ();
        // groundHorizontalLength = groundCollider.size.x;
        groundHorizontalLength = 20.48f;
        Debug.Log(groundHorizontalLength);
    }

    private void Update()
    {
        if (transform.position.x < -groundHorizontalLength)
        {
            RepositionBackground ();
        }
    }

    private void RepositionBackground()
    {
        Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);

        transform.position = (Vector2) transform.position + groundOffSet;
    }
}
