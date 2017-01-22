using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotPlayer : MonoBehaviour {

    public GameObject robberRat;

	// Use this for initialization
	void Start () {
        robberRat = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            robberRat.GetComponent<Wander1>().FSM = ratStates.flee;
        }
    }
}
