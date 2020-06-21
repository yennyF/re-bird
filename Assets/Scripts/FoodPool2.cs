using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPool2 : MonoBehaviour
{
    public int poolSize = 5;
    public GameObject prefab;
    public float spawnRate = 1f;
    public float spawnMinY = -1.2f;
    public float spawnMaxY = 1f;
    
    private GameObject[] objects;
    private float spwanXPosition = 4;
    private int currentIndex;
    private float timeSinseLastSpwaned = 0;

    private Vector2 spawnSize;
    private Vector2 spawnHalfSize;
    private float spawnMarginLeft;

    void Start()
    {

        Vector2 position = new Vector2(0, 3);
        objects = new GameObject[poolSize];
        
        for(int i = 0; i < poolSize; ++i)
        {
            objects[i] = (GameObject)Instantiate (prefab, position, Quaternion.identity);
        }

        spawnSize = prefab.GetComponent<BoxCollider2D>().size;
        spawnHalfSize = new Vector2(spawnSize.x, spawnSize.y) / 2f;
        spawnMarginLeft = spawnSize.x * 0.1f;

        prefab.GetComponent<ScrollingBackground>().enabled = false;
    }

    void Update()
    {
        timeSinseLastSpwaned += Time.deltaTime;

        if(GameControl.instance.gameOver == false && timeSinseLastSpwaned > spawnRate)
        {
            timeSinseLastSpwaned = 0;
            
            Vector3 position = new Vector3(
                spwanXPosition, 
                Random.Range(spawnMinY, spawnMaxY), 
                objects[0].transform.position.z
            );
            objects[0].transform.position = new Vector3(position.x, position.y, position.z);

            // currentIndex++;
            // if(currentIndex >= poolSize)
            // {
            //     currentIndex = 0;
            // }

            int amount = Random.Range(1, poolSize);
            for(int i = 1; i < amount; ++i)
            {
                
                position = formation(position);
                objects[i].transform.position = new Vector3(position.x, position.y, position.z);
            }

            spawnRate = 20f;
        }
    }

    private Vector3 formation(Vector3 position) 
    {
        float option = Random.Range(1, 3);
        Debug.Log(option);

        switch (option)
        {
            case 1: // front
                return new Vector3(
                    position.x + spawnSize.x + spawnMarginLeft, 
                    position.y, 
                    position.z
                );
            case 2: // up
            {
                float y = position.y + spawnSize.y;

                return new Vector3(
                    position.x + spawnSize.x + spawnMarginLeft, 
                    y + spawnHalfSize.y > spawnMaxY ? position.y : y, 
                    position.z
                );
            }
            case 3: // bottom
            {
                float y = position.y - spawnSize.y;

                return new Vector3(
                    position.x + spawnSize.x + spawnMarginLeft, 
                    y - spawnHalfSize.y > spawnMaxY ? position.y : y, 
                    position.z
                );
            }
        } 

        return position;

    }

}
