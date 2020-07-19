using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BirdController>() != null)
        {
            gameObject.transform.position = new Vector3( 0, 3, 0 ); // position out of the screen

            GameControl.instance.BirdScored();
        }
    }
}
