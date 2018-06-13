using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildBuilding : MonoBehaviour {

    public Transform Voxel;
    public Color32 color1;
    public Color32 color2;

    public int maxX;
    public int maxZ;
    public int maxY; 

    

    private int[,,] structure;
    // used for initial creation of the LAyout
    // [X,Z,Y] XZY -> Cell location 

    private buildingCell[,,] cells;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public buildBuilding(int x, int y, int z)
    {

        maxX = x;
        maxY = y;
        maxZ = z;

    }

    private void planBuilding()
    {
        structure = new int[maxX, maxY, maxZ];

        int maxLayerSize = maxX * maxZ;



        int layerSize = maxLayerSize - Random.Range(0, maxLayerSize / 4);
        int lastLayerSize = layerSize;
        int zdirect = 0 ;

        // only for the first floor
        for (int l = 0 ; l > layerSize; l++)
        {

            bool placed = false;

            while (!placed)
            {

                int pickZ = Random.Range(0, maxZ);
                for ( int x = 0; x < maxX; x++)
                {

                    if (structure[x, 0, pickZ] == 0)
                    {

                        structure[x, 0, pickZ] = 1;
                        
                        placed = true; 

                    }


                }
                

            }

        }


        for ( int y = 1 ; y < maxY; y++)
        {

            layerSize = maxLayerSize - Random.Range(0, maxLayerSize/4) - (maxLayerSize - lastLayerSize) ;
            lastLayerSize = layerSize;

            for (int l = 0; l > layerSize; l++)
            {

                bool placed = false;

                while (!placed)
                {

                    int pickZ = Random.Range(0, maxZ);
                    for (int x = 0; x < maxX; x++)
                    {

                        if (structure[x, 0, pickZ] == 0)
                        {

                            structure[x, 0, pickZ] = 1;

                            placed = true;

                        }


                    }


                }

            }

        }



    }

}
