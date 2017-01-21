using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	Vector3 position;

	public GameObject bat;
	public float range;


	// Use this for initialization
	void Start () {
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(DistanceSqr(bat.transform.position) > range*range){
			MoveTowards();
		}
	}

	void MoveTowards(){
		float x = Mathf.Lerp(position.x,bat.transform.position.x,1f);
		float z = Mathf.Lerp(position.z,bat.transform.position.z,1f);
		Vector3 goal = new Vector3(x,position.y,z);
	}

	float DistanceSqr(Vector3 target){
		return Mathf.Pow(position.z-target.z,2) + Mathf.Pow(position.z-target.z,2);
	}
}
