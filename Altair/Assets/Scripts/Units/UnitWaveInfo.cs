
using System.Collections.Generic;

/// <summary>
/// The units info for the wave, the unit to spawn, the amount to spawn, the time between spawns, when to next spawn
/// </summary>
public class UnitWaveInfo  {

    public int unitType;
    public int spawnAmount;
    public double timeBetweenSpawns;
    public double nextSpawn;

    /// <summary>
    /// Constructor for setting all the states
    /// </summary>
    /// <param name="unitType"></param> what unit to spawn
    /// <param name="spawnAmount"></param> how many units to spawn
    /// <param name="timeBetweenSpawns"></param> time between spawns
    /// <param name="nextSpawn"></param> when to next spawn a unit
    public UnitWaveInfo(int unitType, int spawnAmount, double timeBetweenSpawns, double nextSpawn)
    {
        this.unitType = unitType;
        this.spawnAmount = spawnAmount;
        this.timeBetweenSpawns = timeBetweenSpawns;
        this.nextSpawn = nextSpawn;
    }

    override
    public string ToString()
    {
        return "UnitType: " + unitType + " SpawnAmount: " + spawnAmount + " TimeBetweenSpawns: " + timeBetweenSpawns + " NextSpawn: " + nextSpawn;
    }
	
}

