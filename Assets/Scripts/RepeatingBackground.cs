using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private float groundWidth;
    
    void Awake()
    {
        groundWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
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
