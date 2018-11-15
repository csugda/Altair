using UnityEngine;

public class laserAim : MonoBehaviour
{
	public GameObject laser;
	public LineRenderer laserBeam;
	public TargetAcquisition targeter;
	public float height = 1f;

	// Use this for initialization
	void Start()
	{
		laser.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
        if (!targeter.isActiveAndEnabled)
        {
            laser.SetActive(false);
            return;
        }
		if (targeter.target == null || Mathf.Abs(((targeter.rotatingPart.transform.rotation.eulerAngles.y + 360)
			- (targeter.lookRot.eulerAngles.y + 360))) > 5)
		{
            laser.SetActive(false);
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
