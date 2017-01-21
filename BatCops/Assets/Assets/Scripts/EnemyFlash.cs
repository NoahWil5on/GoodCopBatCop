using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlash : MonoBehaviour {
	public GameObject enemy;

	public Texture2D texSaver;
	Texture2D tex;
	Texture2D holder;

	Color[] colorhold;
	Color[] colors;

	int stage;
	float timer;
	float delay;
	bool flash;
	// Use this for initialization
	void Start () {
		tex = new Texture2D(texSaver.width,texSaver.height);
		tex.SetPixels(texSaver.GetPixels());

		GetComponent<MeshRenderer>().material.mainTexture = tex;
		colorhold = tex.GetPixels();
		holder = tex;
		stage = 0;
		timer = .02f;
		flash = false;
	}
	// Update is called once per frame
	void Update () {
		delay += Time.deltaTime;

		if(delay > 2){
			print("flash");
			delay = 0;
			stage = 0;
			flash = true;
		}

		if(flash)
			flash = Flash();
	}
	bool Flash(){
		if(stage == 0){
			colors = tex.GetPixels();
			//colors = GetComponent<MeshRenderer>().material.mainTexture.
			for(int i = 0; i < colors.Length; i++){
				colors[i] = new Color(1,1,1,1);
			}
			tex.SetPixels(colors);
			tex.Apply();
			stage++;
			return true;
		}
		bool change = false;
		if(stage == 1){
			for(int i = 0; i < colors.Length; i++){
				float a = colors[i].a;
				float ah = colorhold[i].a;
				float r = colors[i].r;
				float rh = colorhold[i].r;
				float g = colors[i].g;
				float gh = colorhold[i].g;
				float b = colors[i].b;
				float bh = colorhold[i].b;
				if(a > ah){
					a -= timer;
					change = true;
				}
				if(r > rh){
					r -= timer;
					change = true;
				}
				if(g > gh){
					g -= timer;
					change = true;
				}
				if(b > bh){
					b -= timer;
					change = true;
				}
				colors[i] = new Color(r,g,b,a);
			}
			tex.SetPixels(colors);
			tex.Apply();
			if(!change){
				colors = colorhold;
				stage++;
				return true;
			}
		}
		if(stage == 2){
			for(int i = 0; i < colors.Length; i++){
				float r = colors[i].r;
				float g = colors[i].g;
				float b = colors[i].b;
				float a = colors[i].a;
				if(r-timer > 0){
					change = true;
					r -= timer;
				}
				if(g-timer > 0){
					change = true;
					g -= timer;
				}
				if(b-timer > 0){
					change = true;
					b -= timer;
				}
				colors[i] = new Color(r,g,b,a);		
				if(!change){
					colors[i] = new Color(0,0,0,0);	
				}
			}
			tex.SetPixels(colors);
			tex.Apply();
			if(!change)
				return false;
		}
		return true;
	}
}
