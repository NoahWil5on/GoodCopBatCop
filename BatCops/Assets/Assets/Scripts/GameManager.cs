using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //------------------------------------------------------------------------------>>FIELDS<<
    // Robber Rat
    public GameObject robberRat, RRPrefab;

    [SerializeField]
    GameObject[] SpawnLocations;
    // Array of all exit points the Rat Thief is going for
    private List<GameObject> exitPoints;

    //------------------------------------------------------------------------------>>CONSTRUCTOR<<
    // Use this for initialization
    void Start () {

        // Adds all exit points to a private array list - used for Rat Thief's pathfinding
        exitPoints = new List<GameObject>();
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("SpawnPoint"))
        {
            exitPoints.Add(g);
        }
		int randomSpawn = Random.Range(0,exitPoints.Count);
		Instantiate(robberRat,exitPoints[randomSpawn].transform.position,Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
        
    }
}
