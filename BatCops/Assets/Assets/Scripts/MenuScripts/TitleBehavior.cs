using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void StartGame(){
		UnityEngine.SceneManagement.SceneManager.LoadScene("TheDarkTimes");
	}
	public void EndGame(){
		Application.Quit();
	}
	public void Credits(){
		UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
	}
}
