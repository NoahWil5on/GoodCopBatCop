using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	Vector3 position;

	public GameObject bat;
	public float range;


	// Use this for initialization
	void Start () {
		bat = SimpleMove.instance.gameObject;
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
			MoveTowards();
		
	}

	void MoveTowards(){
		Vector3 goal = Vector3.Lerp(transform.position,bat.transform.position,.1f);
		transform.position = new Vector3(goal.x,position.y,goal.z-.6f);
	}

	float DistanceSqr(Vector3 target){
		return Mathf.Pow(position.x-target.x,2) + Mathf.Pow(position.z-target.z,2);
	}
}
