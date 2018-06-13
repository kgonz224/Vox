using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingCell : MonoBehaviour {

    private Transform vox;

    public Panel[] sides = new Panel[6];
    private Vector3 origin;
    private bool[] layout = new bool[6]; // a array 
    private int size;
    // Use this for initialization

    public GameObject cell = new GameObject("Cell");
    
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public buildingCell(Transform vox, Vector3 origin, int size)
    {

        this.vox = vox;
        this.origin = origin;
        this.size = size;

    }
    public void updateCell(bool[] newLayout)
    {

        layout = newLayout;
        buildCell();

    }

    private void makeUninstantiatedCell() // creates the 6 empty panels  with their appropriate orientations
    {
        for ( int i =  0;i < 6; i++)
        {
            Vector3 offset;
            

            switch (i)
            {

                case 0:
                    sides[i] = new Panel(origin, Quaternion.identity, vox, size);   
                    break;

                case 1:
                    sides[i] = new Panel(origin, Quaternion.Euler(0, 0, 90), vox, size);
                    break;

                case 2:
                    sides[i] = new Panel(origin, Quaternion.Euler(-90, 0, 0), vox, size);
                    break;

                case 3:
                    offset = new Vector3( size / 4f, size/4f, 0);
                    sides[i] = new Panel(origin + offset, Quaternion.Euler(0, 0, -90), vox, size);
                    break;

                case 4:
                    offset = new Vector3(0, size/4f, size / 4f);
                    sides[i] = new Panel(origin + offset, Quaternion.Euler(90, 0, 0), vox, size);
                    break;

                case 5:

                    offset = new Vector3(0, size / 4f, 0);
                    sides[i] = new Panel(origin + offset, Quaternion.identity, vox, size);
                    break;



            }

            sides[i].transform.SetParent(cell.transform);

        }

    }

    public void buildCell()
    {

       
        for(int i  = 0; i < 6; i++)
        {

            if(layout[i])
            {

                sides[i].buildPanel();

            }

        }


    }

}
