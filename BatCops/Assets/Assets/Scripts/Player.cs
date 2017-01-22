using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private GameObject enemy;
    public GameObject backstab;
    public float distanceDetect;
	// Use this for initialization
	void Start () {
		enemy = GameObject.FindGameObjectWithTag("Enemy");
        backstab = GameObject.FindGameObjectWithTag("Backstab");
    }
	
	// Update is called once per frame
	void Update () {

	}
    void OnTriggerEnter(Collider coll)
    {
        if (!backstab.GetComponent<Backstab>().BackColl)
        {
            if(coll.CompareTag("Enemy") && backstab.GetComponent<Backstab>().RatColl == true)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("DeadEnding");
            }
            else if (coll.CompareTag("Enemy") && backstab.GetComponent<Backstab>().RatColl==false)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("GoodEnd");
            }
        }
    }
}
