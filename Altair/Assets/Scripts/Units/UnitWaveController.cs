using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls what wave to spawn and what units to spawn
/// </summary>
public class UnitWaveController : MonoBehaviour {


    /// <summary>
    /// File to read for spawning waves
    /// </summary>
    [SerializeField]
    private TextAsset waveFile;

    /// <summary>
    /// All the waves in the file
    /// </summary>
    private List<WaveInfo> waves;

    /// <summary>
    /// The current wave
    /// </summary>
    private int curentWave = 0;

    /// <summary>
    /// Is the wave finished spawning units
    /// </summary>
    private bool waveFinished = false;

    /// <summary>
    /// Getter for Checking if wave is finished
    /// </summary>
    public bool WaveFinished
    {
        get
        {
            return waveFinished;
        }

    }

    /// <summary>
    /// When starting the program read the wave file
    /// </summary>
    void Start () {
        waves = WaveTextReader.ReadWaveFile(waveFile);
    }
    
    /// <summary>
    /// Gets the wave number
    /// </summary>
    /// <returns></returns> the number of the wave
    public int getWaveNumber()
    {
        return curentWave;
    }

    /// <summary>
    /// Sets the next wave to the current wave 
    /// </summary>
    /// <returns></returns> if there is a next wave
    public bool setNextWave()
    {
        curentWave++;
        if (curentWave > waves.Count)
        {
            curentWave--;
            return false;
        }
        return true;
    }

    /// <summary>
    /// Gets the units to spawn at the current time
    /// </summary>
    /// <param name="time"></param> the time since last check
    /// <returns></returns> the list of units to spawn
    public List<int> getUnitsToSpawn(float time)
    {
        List<int> unitsToSpawn = new List<int>();
        waveFinished = true; // Assume the wave has finished
        foreach (UnitWaveInfo unit in waves[curentWave])
        {
            unit.nextSpawn -= time; // reduce the time till next unit spawn
            if(unit.nextSpawn <= 0 && unit.spawnAmount > 0)
            {
                unitsToSpawn.Add(unit.unitType);
                unit.spawnAmount -= 1;
                unit.nextSpawn = unit.timeBetweenSpawns;
            }
            // If any unit has any more to spawn the wave is not over
            if(unit.spawnAmount > 0)
            {
                waveFinished = false;
            }
        }

        return unitsToSpawn;
    }


}
