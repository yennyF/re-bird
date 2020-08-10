using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [System.NonSerialized] public bool foo = false;
    private static int bar = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BirdController>() != null)
        {
            gameObject.transform.position = new Vector3( 0, 3, 0 ); // position out of the screen

            GameControl.instance.BirdScored();

            // ! Need to be optimized
            FindObjectOfType<AudioManager>().Play("Eat");

            if (foo == true) 
            {
                bar++;
                
                if (bar == 5)
                {
                    other.GetComponent<BirdController>().isHappy = true;
                    //FindObjectOfType<AudioManager>().Play("BirdSound");
                    FindObjectOfType<AudioManager>().Play("Collect");
                    bar = 0;
                }
            }
            else
            {
                bar = 0;
            }
        }
    }
}
