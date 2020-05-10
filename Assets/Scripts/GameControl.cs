using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public bool gameOver = false; 
    public float scrollSpeed = -1.5f;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy (gameObject);
    }
}
