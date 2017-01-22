using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private GameObject enemy;
	public float distanceDetect;
	// Use this for initialization
	void Start () {
		enemy = GameObject.FindGameObjectWithTag("Enemy");
	}
	
	// Update is called once per frame
	void Update () {
		while(!enemy){
			enemy = GameObject.FindGameObjectWithTag("Enemy");
		}
		//print("Distance: " + Vector3.Magnitude(enemy.transform.position-transform.position));
		if(Mathf.Abs(Vector3.Magnitude(enemy.transform.position-transform.position)) < distanceDetect){
			UnityEngine.SceneManagement.SceneManager.LoadScene("GoodEnd");
		}
	}
}
