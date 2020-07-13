/*
    author: nisa
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneBackground : MonoBehaviour
{
    public GameObject[] layers;

    void Start()
    {
        foreach( GameObject obj in layers )
        {
            GameObject clone = Instantiate( obj, obj.transform.parent ) as GameObject;
            float width = clone.GetComponent< SpriteRenderer >().bounds.size.x;

            clone.transform.position = new Vector2(
                obj.transform.position.x + width, 
                obj.transform.position.y
            );
            clone.name = obj.name + 2;
        }        
    }
}
