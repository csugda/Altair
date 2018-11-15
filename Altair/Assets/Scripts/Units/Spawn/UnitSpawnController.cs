using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewWaveEvent : UnityEvent<double> { }

namespace Assets.Scripts.Units
{
    /// <summary>
    /// Controls the waves
    /// </summary>
    public class UnitSpawnController : MonoBehaviour
    {

        public static NewWaveEvent newWaveStart = new NewWaveEvent();

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

        [SerializeField]
        private double timeBetweenWaves = 20;

        private double waveWaitCounter;

        private bool firstWaveClockAnounced = false; 


        // Use this for initialization
        void Start()
        {

            waveWaitCounter = timeBetweenWaves;
        }

        /// <summary>
        /// Starts spawning the first wave
        /// </summary>
        public void startSpawningWaves()
        {
            spawnEnemies = true;
            findTimeForWave();
        }

        /// <summary>
        /// Tells the Unit wave controller to find the time for the wave and then 
        /// announce the time in an event
        /// </summary>
        private void findTimeForWave()
        {
            waveController.findWaveTime();
            newWaveStart.Invoke(waveController.WaveTime + timeBetweenWaves);
        }

        /// <summary>
        /// Trys to start a new wave
        /// </summary>
        public void startNextWave()
        {

            bool moreWaves = waveController.setNextWave();

            if (moreWaves)
            {
                waveWaitCounter = timeBetweenWaves;
                findTimeForWave();
            }
            else
            {
                // Alert For game over
                spawnEnemies = false;
            }
        }

        /// <summary>
        /// Every update it checks the waveController to see what units to spawn
        /// </summary>
        void Update()
        {
            // This is needed since the order of initializing classes is not set in unity
            // causing null pointer expections tring to find the wave time on load
            if (!firstWaveClockAnounced)
            {
                findTimeForWave();
                firstWaveClockAnounced = true;
            }

            float time = Time.deltaTime; // time since last update

            if (spawnEnemies && !waveController.WaveFinished)
            {

                List<int> unitsToSpawn = waveController.getUnitsToSpawn(time);  // get units to spawn
                                                                                //Debug.Log(unitsToSpawn.Count);
                foreach (int unitID in unitsToSpawn)
                {
                    GameObject newEnemy = Instantiate(enemyPrefab[unitID]); // Will crash if unitID not in list of prefabs
                    UnitController enemyControl = newEnemy.GetComponent<UnitController>();
                    enemyControl.setStartLocation(spawnLocation);
                }
            }

            if (spawnEnemies && waveController.WaveFinished)
            {
                waveWaitCounter -= time;

                if (waveWaitCounter < 0)
                {
                    startNextWave();
                }


            }


        }
    }
}
