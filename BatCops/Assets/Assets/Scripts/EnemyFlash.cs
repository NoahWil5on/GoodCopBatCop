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

	MaterialPropertyBlock pBlock;

	// Use this for initialization
	void Start () {
		GetComponent<MeshRenderer>().material.mainTexture = tex;
		colorhold = tex.GetPixels();
		tex = new Texture2D(texSaver.width,texSaver.height);
		tex = texSaver;
		holder = tex;
		stage = 0;
	}
	// Update is called once per frame
	void Update () {
		Flash();

	}
	void Flash(){
		if(stage == 0){
			colors = tex.GetPixels();
			//colors = GetComponent<MeshRenderer>().material.mainTexture.
			for(int i = 0; i < colors.Length; i++){
				colors[i] = new Color(1,1,1,1);
			}
			tex.SetPixels(colors);
			tex.Apply();
			stage++;
			return;
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
					a -= .02f;
					change = true;
				}
				if(r > rh){
					r -= .02f;
					change = true;
				}
				if(g > gh){
					g -= .02f;
					change = true;
				}
				if(b > bh){
					b -= .02f;
					change = true;
				}
				colors[i] = new Color(r,g,b,a);
			}
			tex.SetPixels(colors);
			tex.Apply();
			if(!change){
				stage++;
				return;
			}
		}
		if(stage == 2){
			for(int i = 0; i < colors.Length; i++){
				float r = colors[i].r;
				float g = colors[i].g;
				float b = colors[i].b;
				float a = colors[i].a;
				if(r-.1f > 0){
					r -= .1f;
				}
				if(g-.1f > 0){
					g -= .1f;
				}
				if(b-.1f > 0){
					b -= .1f;
				}
				colors[i] = new Color(r,g,b,a);		
			}
			tex.SetPixels(colors);
			tex.Apply();	
		}
	}
}
