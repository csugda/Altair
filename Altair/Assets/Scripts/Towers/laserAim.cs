using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserAim : MonoBehaviour
{
	public GameObject laser;
	public LineRenderer laserBeam;
	public TargetAcquisition targeter;
	public float height = 1f;

	private float coolDown;
	public float coolDownVal = .175f;
	// Use this for initialization
	void Start()
	{
		coolDown = coolDownVal;
	}

	// Update is called once per frame
	void Update()
	{
		if (targeter.target == null)
		{
			laser.SetActive(false);
			coolDown = coolDownVal;
		}
		else
		{
			if (coolDown > 0)
			{
				coolDown -= Time.deltaTime;
			}
			else
			{
				laser.SetActive(true);
				Transform target = targeter.target;
				LineRenderer laserBeam = laser.GetComponentInChildren<LineRenderer>();
				laserBeam.SetPosition(0, laserBeam.gameObject.transform.position);
				laserBeam.SetPosition(1, new Vector3(target.position.x, height, target.position.z));
			}

		}
	}
}
