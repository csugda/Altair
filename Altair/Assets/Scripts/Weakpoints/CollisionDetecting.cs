using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CollisionDetecting : MonoBehaviour {
    private Rigidbody rb;
    private int hits;
    public Text hitText;

    // Use this for initialization
    void Start () {
        hits = 0;
        hitText.text = "Hits: " + hits.ToString();
        setHitText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            hits = hits + 1;
            setHitText();
        }
    }

    void setHitText()
    {
        hitText.text = "Hits : " + hits.ToString();
    }
}

