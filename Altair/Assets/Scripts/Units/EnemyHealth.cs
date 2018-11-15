using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DecreaseHealthEvent : UnityEvent<float>{}
public class EnemyHealth : MonoBehaviour {
    public float health = 100;
    public DecreaseHealthEvent takeDammage = new DecreaseHealthEvent();
	// Use this for initialization
	void Start () {
        this.takeDammage.AddListener(this.decreaseHealth);
	}
	

    void decreaseHealth(float dammageAmmount)
    {
        health -= dammageAmmount;
        if (health < 0)
        {
            //TODO: Play death animation
            Destroy(this.gameObject);
        }
    }
}
