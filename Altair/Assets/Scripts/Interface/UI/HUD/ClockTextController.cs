﻿using Assets.Scripts.Units;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClockTextController : MonoBehaviour {
    public double clockTime = 00;
	// Use this for initialization
	void Start () {
        UnitSpawnController.newWaveStart.AddListener(this.updateClockTime);
	}

    private void Update()
    {
        clockTime -= Time.deltaTime;
        int sec =  clockTime >= 0 ? (int)clockTime : 00;
        int ms = clockTime >= 0 ?  (int)((clockTime - sec) * 10) : 00;
        this.gameObject.GetComponent<Text>().text = sec + ":" + ms;
    }

    public void updateClockTime(double time)
    {
        this.clockTime = time;
    }
	
	
}
