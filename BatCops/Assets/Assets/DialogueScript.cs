using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DialogueScript : MonoBehaviour {


    [SerializeField]
    AudioClip[] clips;
    public Text text;
    [SerializeField]
    string[] strings;
    [SerializeField]
    Sprite[] sprites; //bat is 0, cat is 1
    [SerializeField]
    Image image;
    int curClip = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)){
            
            if (curClip < 23)
            {
                text.text = strings[curClip];
                GetComponent<AudioSource>().clip = clips[curClip];
                GetComponent<AudioSource>().Play();
            }
            curClip += 1;

        }
        if(curClip == 1)
        {
            image.sprite = sprites[0];
        }
        if (curClip == 2)
        {
            image.sprite = sprites[1];
        }
        if (curClip == 3)
        {
            image.sprite = sprites[0];
        }
        if (curClip == 4)
        {
            image.sprite = sprites[1];
        }
        if (curClip == 5)
        {
            image.sprite = sprites[0];
        }
        if (curClip == 6)
        {
            image.sprite = sprites[1];
        }
        if (curClip >= 7)
        {
            SceneManager.LoadScene("Batcops");
        }
	}
}
