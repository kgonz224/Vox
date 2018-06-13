using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRenderer : MonoBehaviour {
  
    /*
     * 
     * 
     * This file has been retired and is no longer used. Kept in the project to have a reference to build buildBuilding from
     * 
     * 
     * 
     * 
     * 
     * */

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

        for (int r = 0; r < length; r++)
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

        for (int r = 0; r < width; r++)
        {
            for (int c = 0; c < height; c++)
            {

                Transform tempVoxel = Voxel;
                float topHeight = Random.Range(0.0f, wallRoughness);

                for (int i = 0; i < thic; i++)
                {
                    backWall[i, r, c] = Instantiate(tempVoxel, new Vector3(topHeight + (length+ i)/4f  , c / 4f , -r / 4f ), Quaternion.identity);
                    backWall[i, r, c].GetComponent<Renderer>().material.color = Color32.Lerp(floorColor1, floorColor2, Random.Range(0.0f, 1.0f));
                }

            }
        }



    }

    
   
    void makeDoors()
    {

        Vector3 sideDoorLocation = new Vector3();


    }

    // Update is called once per frame
    void Update () {
		
	}
}
