using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Collections.Generic;

/// <summary>
/// This class reads a file to create all the wave information
/// </summary>
public class WaveTextReader {

    /// <summary>
    /// Takes a file opens it and parses the values to create wave information
    /// </summary>
    /// <param name="waveTextFile"></param> The file to read
    /// <returns></returns> List of all waveInfo
    [MenuItem("Tools/Read file")]
    public static List<WaveInfo> ReadWaveFile(TextAsset waveTextFile)
    {
        List<WaveInfo> waves = new List<WaveInfo>(); // All the waves in the file
        //Read the text from directly from the file
        string file = waveTextFile.text;
        string[] lines = file.Split('\n'); // Each Line is a wave

        // Go through all lines
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i]; // In to check
            if (!isComment(line[0])) // First char Would contain comment symbol
            {
                waves.Add(processWave(line));
            }

        }

        return waves;
    }

    /// <summary>
    /// Checks it the first leter of a line is a # which is a comment symbol
    /// </summary>
    /// <param name="letter"></param> the char to check 
    /// <returns></returns> if char is a comment symbol
    private static bool isComment(char letter)
    {
        return letter == '#';
    }

    /// <summary>
    /// Process a line and creates the wave info
    /// </summary>
    /// <param name="line"></param> the line
    /// <returns></returns> the info for the wave
    private static WaveInfo processWave(string line)
    {
        //Debug.Log(line);
        WaveInfo wave = new WaveInfo();

       string[] unitInfo = line.Split(';');
       for (int i = 0; i < unitInfo.Length; i++)
        {
            string[] parts = unitInfo[i].Split(',');
            if(parts.Length == 4) // do not run valid inputs
            {
                wave.Add(processUnitInfo(parts));
                //Debug.Log(unitInfo[i]);
            }
        }

        return wave;
    }

    /// <summary>
    /// Processes each units actions of the wave 
    /// </summary>
    /// <param name="parts"></param> The units values for the wave
    /// <returns></returns> the units info for the wave
    private static UnitWaveInfo processUnitInfo(string[] parts)
    {
        int unitType = Convert.ToInt32(parts[0]);
        int spawnAmount = Convert.ToInt32(parts[1]);
        double timeBetweenSpawns = Convert.ToDouble(parts[2]);
        double nextSpawn = Convert.ToDouble(parts[3]);

        return new UnitWaveInfo(unitType, spawnAmount, timeBetweenSpawns, nextSpawn);
    }
}
