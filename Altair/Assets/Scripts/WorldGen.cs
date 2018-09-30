using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour {

    private int NumColumns = 15;
    private int NumRows = 15;

    public GameObject tilePrefab;
    //public GameObject towerPrefab;

    // Use this for initialization
    void Start()
    {

        for (int column = 0; column < NumColumns; column++)
        {
            for (int row = 0; row < NumRows; row++)
            {
                
                GameObject newTile = GameObject.Instantiate(tilePrefab, new Vector3(column, 0, row), Quaternion.Euler(0,0,0));
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
