using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("up"))
			transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z+speed);
		if(Input.GetKey("down"))
			transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z-speed);
		if(Input.GetKey("left"))
			transform.position = new Vector3(transform.position.x-speed,transform.position.y,transform.position.z);
		if(Input.GetKey("right"))
			transform.position = new Vector3(transform.position.x+speed,transform.position.y,transform.position.z);
	}
}
