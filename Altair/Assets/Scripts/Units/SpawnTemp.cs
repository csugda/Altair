using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTemp : MonoBehaviour {
    public GameObject enemy;
    public float rate;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", 1f, rate);
	}

    void Spawn()
    {
        Instantiate(enemy, this.gameObject.transform);
    }
}
