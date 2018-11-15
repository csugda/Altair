using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAcquisition : MonoBehaviour {
    // Class Variables
    public Transform target = null;
    public Transform rotatingPart;
	public Quaternion lookRot;

    public float range = 20f;
    public float updateTargetRate = 0.5f; //time in seconds
    public float traverseRate = 10f;
    public string enemyTag = "Enemy";
    
	// Use this for initialization
	void Start () {
        // Check for new target a lot fewer times per second
        // InvokeRepeating("UpdateTarget", .0f, updateTargetRate);
	}

	/// <summary>
	/// Determines which enemy to target based on range of turret
	///		-will pick the first enemy to enter its range
	///		-will track that enemy until it leaves range or dies
	///		-will then swap to the closest enemy within range
	/// </summary>
	void UpdateTarget()
    {
        // Create an array of Gameobjects with the corresponding tag within range
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        //loop through enemies to find nearest one
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
				target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
	// Update is called once per frame
	void Update () {
		if (target == null)
		{
			UpdateTarget();
			return;
		}
		if (Vector3.Distance(transform.position, target.position) > range)
		{
			target = null;
			return;
		}
        //determine direction to target
        Vector3 dir = target.position - transform.position;
        //calculate rotation 
        lookRot = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotatingPart.rotation, lookRot, Time.deltaTime * traverseRate).eulerAngles;
        //rotate to target
        rotatingPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
