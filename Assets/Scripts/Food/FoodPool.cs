using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPool : MonoBehaviour
{
    public GameObject spawn;
    public int poolSize = 20;
    public float spawnRate = 2f;

    private float spawnStartX = 4;
    private float spawnMinY = -1f;
    private float spawnMaxY = 1.4f;

    private Vector2 spawnSize;
    private Vector2 spawnHalfSize;
    private float spawnSpaceWidth;
    
    private GameObject[] spawns;
    private int currentIndex = 0;
    private float timeSinseLastSpwaned = 0;
    private GameObject formationSpawnEnd;

    void Start ()
    {
        spawn.transform.position = new Vector3( 0, 3, 0 ); // position out of the screen

        spawns = new GameObject[ poolSize ];
        
        for ( int i = 0; i < poolSize; ++i )
        {
            spawns[ i ] = ( GameObject ) Instantiate( spawn );

            // float k = Random.Range( 0.0f, 1.0f );
            // if ( k < 0.2f ) // temporal test
            // {
            //     spawns[ i ].GetComponent< SpriteRenderer >().color = Color.blue;
            // }
        }

        spawnSize = spawn.GetComponent< BoxCollider2D >().size;
        spawnHalfSize = new Vector2( spawnSize.x, spawnSize.y ) / 2f;
        spawnSpaceWidth = spawnSize.x * 0.6f;

    }

    void Update ()
    {

        if ( GameControl.instance.gameOver == false) 
        {
            if ( formationSpawnEnd == null || formationSpawnEnd.transform.position.x <= spawnStartX )
            {
                timeSinseLastSpwaned += Time.deltaTime;

                if ( timeSinseLastSpwaned > spawnRate )
                {
                    timeSinseLastSpwaned = 0;
                    
                    List< GameObject > combo = SpawnCombo();

                    formationSpawnEnd = combo[ combo.Count - 1 ];
                }
            }
        }
    }

    private List< GameObject > SpawnCombo()
    {
        // int amount = Random.Range( 1, 6 ); // min [inclusive] and max [exclusive]
        int amount = 5;
        List< GameObject > combo = new List< GameObject >();

        Vector3 position = new Vector3( spawnStartX, Random.Range( spawnMinY, spawnMaxY ), spawn.transform.position.z );
        spawns[ currentIndex ].transform.position = new Vector3( position.x, position.y, position.z );
        spawns[ currentIndex ].GetComponent<Food>().foo = ( amount == 5 ) ? true : false;

        combo.Add( spawns[ currentIndex ] );

        currentIndex = ( currentIndex == poolSize - 1 ) ? 0 : currentIndex + 1;

        for ( int i = 2; i <= amount; ++i )
        {
            float x = position.x + spawnSize.x + spawnSpaceWidth;
            float y = 0;

            switch ( Random.Range( 1, 3 ) )
            {
                case 1: // front
                    y = position.y;
                    break;
                case 2: // up
                    y = position.y + spawnSize.y + spawnHalfSize.y;
                    y = y > spawnMaxY ? position.y : y;
                    break;
                case 3: // bottom
                    y = position.y - spawnSize.y - spawnHalfSize.y;
                    y = y < spawnMinY ? position.y : y;
                    break;
            } 

            position.Set( x, y, position.z);
            spawns[ currentIndex ].transform.position = new Vector3( position.x, position.y, position.z );
            spawns[ currentIndex ].GetComponent<Food>().foo = ( amount == 5 ) ? true : false;

            combo.Add( spawns[ currentIndex ] );

            currentIndex = ( currentIndex == poolSize - 1 ) ? 0 : currentIndex + 1;
        }

        return combo;
    }
}
