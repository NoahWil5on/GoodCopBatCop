using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkTimes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			//Go To Next Scene

			//To make game playable:
			UnityEngine.SceneManagement.SceneManager.LoadScene("MapScene");
		}
	}
}
