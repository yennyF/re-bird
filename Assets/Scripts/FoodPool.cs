using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPool : MonoBehaviour
{
    public int poolSize = 5;
    public GameObject prefab;
    public float spawnRate = 4f;
    public float spawnMinX = -1.2f;
    public float spawnMaxX = 1f;
    
    private GameObject[] objects;
    private float spwanXPosition = 4;
    private int currentIndex;
    private float timeSinseLastSpwaned = 0;

    void Start()
    {
        Vector2 position = new Vector2(0, 3);
        objects = new GameObject[poolSize];
        
        for(int i = 0; i < poolSize; ++i)
        {
            objects[i] = (GameObject)Instantiate (prefab, position, Quaternion.identity);
        }
        
    }

    void Update()
    {
        timeSinseLastSpwaned += Time.deltaTime;

        if(GameControl.instance.gameOver == false && timeSinseLastSpwaned > spawnRate)
        {
            timeSinseLastSpwaned = 0;
            
            float spwanYPosition = Random.Range(spawnMinX, spawnMaxX);
            objects[currentIndex].transform.position = new Vector3(spwanXPosition, spwanYPosition);

            currentIndex++;
            if(currentIndex >= poolSize)
            {
                currentIndex = 0;
            }
        }
    }
}
