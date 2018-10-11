using Assets.Scripts.Map.Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawnController : MonoBehaviour {

    [SerializeField]
    private GameObject spawnLocation;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private PathType endGoal;

    [SerializeField]
    private bool spawnEnemies = false;

    [SerializeField]
    private double spawnTime = 0.5;

    private double lastSpawn = 0.0;

    // Use this for initialization
    void Start () {

        



    }
	
	// Update is called once per frame
	void Update () {

        lastSpawn += Time.deltaTime;

        if (spawnEnemies && lastSpawn > spawnTime)
        {
            GameObject newEnemy = Instantiate(enemyPrefab);
            UnitController enemyControl = newEnemy.GetComponent<UnitController>();
            enemyControl.setStartLocation(spawnLocation);
            enemyControl.setEndGoal(endGoal);
            lastSpawn = 0.0;
        }
        
		
	}
}
