using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander1 : MonoBehaviour {
    public float radius = 10.0f;//the radius of how far it will travel
    public float wanderT;//how loong the obj will wander for
    public GameObject door;
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
        WanderAround();
    }

    public void WanderAround()
    {

            nav.SetDestination(door.transform.position);
            Debug.DrawLine(transform.position, newPos, Color.red);
            print("Position: " + transform.position);
            print("Going to: " + newPos);
            timer = 0;
        
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
