using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : MonoBehaviour {
    public float radius = 10.0f;//the radius of how far it will travel
    public float wanderT;//how loong the obj will wander for

    protected NavMeshAgent nav;
    protected float timer;//the timer of the wander

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
        timer += Time.deltaTime;
        if(timer >= wanderT)
        {
            Vector3 newPos = RandomLocNav(this.transform.position, radius, -1);
            nav.SetDestination(newPos);
            Debug.DrawLine(transform.position, newPos, Color.red);
            timer = 0;
        }
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
