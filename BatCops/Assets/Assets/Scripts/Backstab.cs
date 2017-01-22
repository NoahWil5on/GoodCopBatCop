using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backstab : MonoBehaviour {

    bool backColl;
    bool ratColl;


    public bool BackColl
    {
        get { return backColl; }
    }

    public bool RatColl
    {
        get { return ratColl; }
    }

	// Use this for initialization
	void Start () {
        backColl = false;
        ratColl = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //checking to see if the rat collides with the back of you
    void OnTriggerEnter(Collider other)
    {
        backColl = true;

        if (other.CompareTag("Enemy"))
        {

            Debug.Log("EEEE");
            //UnityEngine.SceneManagement.SceneManager.LoadScene("DeadEnding");
            ratColl = true;
        }

        backColl = false;
    }
}
