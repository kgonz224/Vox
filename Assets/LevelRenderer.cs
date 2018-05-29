using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelRenderer : MonoBehaviour {
    // this should be renamed to Room Renderer. This is a test for various functions that should be able to apply to all rooms.

    //Global Values
    public Transform Voxel;
    public Color32 floorColor1;
    public Color32 floorColor2;
    public int thic;
    public int tileSize;
    public int len;
    public int wid;
    public int hgt;

    //Floor Specific Values
    public Transform[,,] floor = null;
    public float floorRoughness;

    //Side Wall Specific Values
    public Transform[,,] sideWall = null;

    public float wallRoughness;

    public Transform[,,] backWall = null; 

    
   
   
    // Use this for initialization
    void Start () {

        generateFloor(); // render floor
        generateWalls(); // render walls
        generateDoors( 2,1); // crate the doors



	}

    void generateFloor()                            // generate random floor structure
    {
        int length = len * tileSize;                // get number of voxels needed to satisfy dimensions 
        int width = wid * tileSize;


        floor = new Transform[length, width, thic]; //x z y


        // loop through all grid and create values
        for (int r = 0; r < length; r++)
        {
            for (int c = 0; c < width; c++)
            {
                Transform tempVoxel = Voxel;                            // creates a temp voxel so each one is different
                float topHeight = Random.Range(0.0f, floorRoughness);   // gets the varience in texture of the floor
                for (int i = 0; i < thic; i++)                          // adjusts to the thiccness
                {
                    floor[r, c, i] = Instantiate(tempVoxel, new Vector3(r / 4f, topHeight - i/4f , c / -4f), Quaternion.identity);              // create a prefab , fill it into the grid
                    floor[r, c, i].GetComponent<Renderer>().material.color = Color32.Lerp(floorColor1, floorColor2, Random.Range(0.0f, 1.0f));  // get a color in the range
                }
            }
        }


    }
    void generateWalls()
    {
        int length = len * tileSize;
        int height = hgt * tileSize;
       

       sideWall = new Transform[length, thic, height];  // x z y

        for (int r = 0; r < length; r++)                // Create sidewall based on dimensions
        {
            for (int c = 0; c < height; c++)
            {
                Transform tempVoxel = Voxel;
                float topHeight = Random.Range(0.0f, wallRoughness);
                for (int i = 0; i < thic; i++)
                {
                    sideWall[r, i, c] = Instantiate(tempVoxel, new Vector3(r / 4f, c / 4f, topHeight - i / 4f), Quaternion.identity);
                    sideWall[r, i, c].GetComponent<Renderer>().material.color = Color32.Lerp(floorColor1, floorColor2, Random.Range(0.0f, 1.0f));
                }
            }
        }

        int width = wid * tileSize;
        backWall = new Transform[thic, width, height];
            
        for (int r = 0; r < width; r++)                 // Create back wall based off dimensions
        {
            for (int c = 0; c < height; c++)
            {

                Transform tempVoxel = Voxel;
                float topHeight = Random.Range(0.0f, wallRoughness);

                for (int i = 0; i < thic; i++)
                {
                    backWall[i, r, c] = Instantiate(tempVoxel, new Vector3(topHeight + (length+ i-1)/4f  , c / 4f , -r / 4f ), Quaternion.identity);
                    backWall[i, r, c].GetComponent<Renderer>().material.color = Color32.Lerp(floorColor1, floorColor2, Random.Range(0.0f, 1.0f));
                }

            }
        }



    }

    
   
    void generateDoors( int height, int width)
    {
        int doorPosition = ((int)((len - width) / 2) * tileSize );
        

        float doorDepth = sideWall[ doorPosition, 0, 1].position.z;

        for ( int x = doorPosition ; x < doorPosition + width*tileSize; x++)
        {

            for( int y = thic;  y< thic + height*tileSize; y++)
            {
  
                for ( int z = 0; z < thic; z++)
                {

                    if( z == 1)
                    {
                        sideWall[x, z, y].position = new Vector3( sideWall[x, z, y].position.x,  sideWall[x, z, y].position.y, doorDepth);
                        sideWall[x, z, y].GetComponent<Renderer>().material.color = Color.black;
                    }
                    else
                    {
                        Destroy(sideWall[x, z, y].gameObject);
                        sideWall[x, z, y] = null;
                    }

                }

            }

        }



    }

    // Update is called once per frame
    void Update () {
		
	}
}
