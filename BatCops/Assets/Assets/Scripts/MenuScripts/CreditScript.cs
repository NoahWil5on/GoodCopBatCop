using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)){
			UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
		}
	}
	void Return(){
		
	}
}
