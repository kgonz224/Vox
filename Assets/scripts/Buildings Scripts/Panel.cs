using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour {

    private Transform vox;

    private Quaternion orientation;
    private Vector3 origin;

    private int size; // panel size

    GameObject panel = new GameObject("Panel");

    public Transform[,] panelVoxs; 

    // Use this for initialization
    void Start () {
        Instantiate(panel, origin, orientation);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Panel(Vector3 origin, Quaternion orientation, Transform vox, int size)
    {

        this.orientation = orientation;
        this.origin = origin;
        this.vox = vox;
        this.size = size;

      
    }

    public void buildPanel()
    {
        panelVoxs = new Transform[size, size];
        for (int x = 0; x < size; x++)
        {

           for ( int z = 0; z < size; z++)
            {

                Transform tempVoxel = vox;

                panelVoxs[x,z] = Instantiate(tempVoxel, new Vector3(x / 4, 0, z / 4), Quaternion.identity);
                panelVoxs[x, z].transform.SetParent(panel.transform);
                // panelVoxs[x,z].GetComponent<Renderer>().material.color = Color32.Lerp(floorColor1, floorColor2, Random.Range(0.0f, 1.0f));  // get a color in the range

            }

        }


    }
}
