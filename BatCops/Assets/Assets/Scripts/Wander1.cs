using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander1 : MonoBehaviour {
    public float radius = 10.0f;//the radius of how far it will travel
    public float wanderT;//how loong the obj will wander for
    public GameObject door;
    public GameObject fleeingTarget;
    public GameObject random;

    public int multiplyBy;
    public float fleeRadius = 50.0f; // The radius of how close it has to be to fleeingTarget before it runs

    private NavMeshAgent nav;
    private float timer;//the timer of the wander
    private Vector3 newPos;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        timer = wanderT;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, fleeingTarget.transform.position);
        if (dist > fleeRadius)
        {
            Seek();
            print("Seeking");
        }
        else
        {
            Flee();
            print("Fleeing");
        }
    }

    public void Seek()
    {
        nav.SetDestination(door.transform.position);
        Debug.DrawLine(transform.position, newPos, Color.red);
        timer = 0;
        
    }

    public void Flee()
    {
        Vector3 runTo = multiplyBy * (transform.position - fleeingTarget.transform.position);
        random.transform.position = runTo;
        nav.SetDestination(runTo);
    }

    public Vector3 RandomLocNav(Vector3 currLoc, float dist, int layer)
    {
        Vector3 randDir = Random.insideUnitSphere * dist;

        randDir += currLoc;

        NavMeshHit hitting;

        NavMesh.SamplePosition(randDir, out hitting, dist, layer);

        return hitting.position;
    }
}