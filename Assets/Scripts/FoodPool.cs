using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPool : MonoBehaviour
{
    public GameObject spawn;
    public int poolSize = 20;
    public float spawnRate = 2f;

    private float spawnXPosition = 4;
    private float spawnMinY = -1f;
    private float spawnMaxY = 1.4f;

    private Vector2 spawnSize;
    private Vector2 spawnHalfSize;
    private float spawnMarginLeft;
    
    private GameObject[] spawns;
    private int currentIndex = 0;
    private float timeSinseLastSpwaned = 0;
    private GameObject formationSpawnEnd;
    private int prevIndex;

    void Start ()
    {
        spawn.transform.position = new Vector3( 0, 3, 0 );

        spawns = new GameObject[ poolSize ];
        Debug.Log(Color.blue);
        for ( int i = 0; i < poolSize; ++i )
        {
            spawns[ i ] = ( GameObject ) Instantiate( spawn );
            float k = Random.Range( 0.0f, 1.0f );
            Debug.Log( k );
            if ( k < 0.2f )
            {
                spawns[ i ].GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }

        spawnSize = spawn.GetComponent< BoxCollider2D >().size;
        spawnHalfSize = new Vector2( spawnSize.x, spawnSize.y ) / 2f;
        spawnMarginLeft = spawnSize.x * 0.1f;

    }

    void Update ()
    {

        if ( GameControl.instance.gameOver == false) 
        {
            if ( formationSpawnEnd == null || formationSpawnEnd.transform.position.x <= spawnXPosition )
            {
                timeSinseLastSpwaned += Time.deltaTime;

                if ( timeSinseLastSpwaned > spawnRate )
                {
                    timeSinseLastSpwaned = 0;
                    
                    prevIndex = currentIndex;

                    Vector3 position = new Vector3( 
                        spawnXPosition, 
                        Random.Range( spawnMinY, spawnMaxY ), 
                        spawn.transform.position.z
                    );
                    spawns[ currentIndex++ ].transform.position = new Vector3( position.x, position.y, position.z );
                    
                    if ( currentIndex >= poolSize )
                    {
                        currentIndex = 0;
                    }

                    int amount = Random.Range( 0, 4 );

                    for ( int i = 0; i < amount; ++i )
                    {
                        prevIndex = currentIndex;

                        position = formation( position );
                        spawns[ currentIndex++ ].transform.position = new Vector3( position.x, position.y, position.z );
                        
                        if ( currentIndex >= poolSize )
                        {
                            currentIndex = 0;
                        }
                    }

                    formationSpawnEnd = spawns[ prevIndex ];

                }
            }
        }
    }

    private void Spawn ()
    {

    }

    private Vector3 formation ( Vector3 position ) 
    {
        float option = Random.Range( 1, 3 );

        switch ( option )
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
