using Assets.Scripts.Map.Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the waves
/// </summary>
public class UnitSpawnController : MonoBehaviour {

    /// <summary>
    /// The spawn location 
    /// </summary>
    [SerializeField]
    private GameObject spawnLocation;

    /// <summary>
    /// List of the enemies to spawn
    /// If the wave has an enemy not in this list it will crash
    /// </summary>
    [SerializeField]
    private List<GameObject> enemyPrefab;

    /// <summary>
    /// Start spawning enemies
    /// </summary>
    [SerializeField]
    private bool spawnEnemies = false;


    /// <summary>
    /// The wave controller
    /// </summary>
    [SerializeField]
    private UnitWaveController waveController;

    // Use this for initialization
    void Start () {


    }

    /// <summary>
    /// Every update it checks the waveController to see what units to spawn
    /// </summary>
    void Update() {

        float time = Time.deltaTime; // time since last update
        
        if (spawnEnemies && !waveController.WaveFinished){

            List<int> unitsToSpawn = waveController.getUnitsToSpawn(time);  // get units to spawn
            //Debug.Log(unitsToSpawn.Count);
            foreach (int unitID in unitsToSpawn)
            {
                GameObject newEnemy = Instantiate(enemyPrefab[unitID]); // Will crash if unitID not in list of prefabs
                UnitController enemyControl = newEnemy.GetComponent<UnitController>();
                enemyControl.setStartLocation(spawnLocation);
            }
        }
        
		
	}
}
