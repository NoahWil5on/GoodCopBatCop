using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotPlayer : MonoBehaviour {

    public GameObject robberRat;
    public GameObject player;

    // Use this for initialization
    void Start () {
        robberRat = transform.parent.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            robberRat.GetComponent<SeekFlee>().FSM = ratStates.flee;
        }
    }
}
