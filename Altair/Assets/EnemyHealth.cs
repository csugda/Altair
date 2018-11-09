using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    private Rigidbody rb;
    public int health = 3;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Time.deltaTime, 0, 0);
    }

    void decreaseHealth(int healthAmount)
    {
        health = health - healthAmount;
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Damage"))
    //    {
    //        Destroy(other.gameObject);
    //        health = health - 1;
    //    }
    //    if(health == 0)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
    
}

