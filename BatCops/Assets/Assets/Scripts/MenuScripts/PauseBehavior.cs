using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBehavior : MonoBehaviour {
	public GameObject canvas;

	bool music;
	bool voices;
	// Use this for initialization
	void Start () {
		music = true;
		voices = true;
		canvas.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(canvas.activeInHierarchy){
				canvas.SetActive(false);
				Time.timeScale = 1;
			}
			else{
				canvas.SetActive(true);
				Time.timeScale = 0;
			}
		}
	}
	public void Resume(){
		canvas.SetActive(false);
		Time.timeScale = 1;
	}
	public void Quit(){
		UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("TitleScene");
	}
	public void Restart(){
		SimpleMove.instance.gameObject.AddComponent<BoxCollider>();
		UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MapScene");
	}
	public void VoiceCheck(){
		voices = !voices;
	}
	public void MusicCheck(){
		music = !music;
	}
}
