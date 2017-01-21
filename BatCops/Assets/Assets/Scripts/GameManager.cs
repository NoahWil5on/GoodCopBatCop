using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //------------------------------------------------------------------------------>>FIELDS<<
    // Robber Rat
    public GameObject robberRat;

    // Array of all exit points the Robber Thief is going for
    private List<GameObject> exitPoints;

    // Keeps track of Vehicle class for Robber Rat
    private Wander robberWander;
    private int find;

    //------------------------------------------------------------------------------>>CONSTRUCTOR<<
    // Use this for initialization
    void Start () {
        // Adds all exit points to a private array list - used for Rat Thief's pathfinding
        exitPoints = new List<GameObject>();
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("ExitPoint"))
        {
            exitPoints.Add(g);
        }

        find = 0;

        robberWander = robberRat.GetComponent<Wander>();
	}
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(robberRat.transform.position, exitPoints[find].transform.position);
        if(find > exitPoints.Count - 1)
        {
            find = 0;
        }

    }
}
