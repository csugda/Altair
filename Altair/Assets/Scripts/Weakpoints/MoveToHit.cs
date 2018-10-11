using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToHit : MonoBehaviour {
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-Time.deltaTime, 0, 0);
    }

}
