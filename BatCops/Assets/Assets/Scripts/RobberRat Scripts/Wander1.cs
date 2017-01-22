using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ratStates
{
    initialWander,
    flee,
    timedWander,
    seek
}

public class Wander1 : Wander {
    
    private GameObject door;
    public GameObject fleeingTarget;

    public int multiplyBy = 5;
    public float fleeRadius = 30.0f; // The radius of how close it has to be to fleeingTarget before it runs
	public float detectDist;
    
    private Vector3 newPos;
    private bool dead;

    // Parts for the Finite State Machine
    private ratStates fsm;
    private float timePassed;
    private bool hasWandered;

    public float controlledWander = 60.0f;   // Can manually change amount of time passing
    public float controlledTimedWander = 5.0f;
    

    public bool Dead
    {
        get { return dead; }
        set { dead = value; }
    }

    public ratStates FSM
    {
        get { return fsm; }
        set { fsm = value; }
    }


    void Start()
    {
		door = GameObject.Find("Door");
        nav = GetComponent<NavMeshAgent>();
        timer = wanderT;
        dead = false;

        fsm = ratStates.initialWander;
        timePassed = 0.0f;
        hasWandered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(fsm == ratStates.initialWander)
        {
            print("FSM: initial wander");
            timePassed += Time.deltaTime;

            WanderAround();
            if(timePassed > controlledWander)
            {
                fsm = ratStates.seek;
                timePassed = 0;
            }
        }
        else if(fsm == ratStates.flee)
        {
            print("FSM: flee");
            Flee();
        }
        else if(fsm == ratStates.timedWander)
        {
            print("FSM: timed wander");
            timePassed += Time.deltaTime;

            WanderAround();
            if(timePassed > controlledTimedWander)
            {
                fsm = ratStates.seek;
            }
        }
        else
        {
            print("FSM: seek");
            Seek();
        }
		if(Mathf.Abs(Vector3.Magnitude(door.transform.position-transform.position)) < detectDist){
			UnityEngine.SceneManagement.SceneManager.LoadScene("BadEnd");
		}
    }
    
    public void Seek()
    {
        nav.SetDestination(door.transform.position);
        //Debug.DrawLine(transform.position, newPos, Color.red);
        timer = 0;
    }

    public void Flee()
    {
        Vector3 runTo = multiplyBy * (transform.position - fleeingTarget.transform.position);
        nav.SetDestination(runTo);

        // Checks to see if this GameObject should still be fleeing
        float dist = Vector3.Distance(transform.position, fleeingTarget.transform.position);
        if (dist > fleeRadius)
        {
            if (!hasWandered)
            {
                fsm = ratStates.timedWander;
            }
            else
            {
                fsm = ratStates.seek;
            }
        }
    }
}
