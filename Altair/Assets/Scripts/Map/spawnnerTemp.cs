using Assets.Scripts.Map.Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnnerTemp : MonoBehaviour {
    public GameObject enemyPrefab;
    public PathNode start;
    public PathType goal;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", 0f, 5f);
	}
	void Spawn()
    {
        GameObject unit = Instantiate(enemyPrefab, this.transform);
        unit.GetComponent<UnitController>().Setup(start, goal);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
