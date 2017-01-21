using UnityEngine;
using System.Collections;

//use the Generic system here to make use of a Flocker list later on
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]

public class Vehicle : MonoBehaviour
{

    //------------------------------------------------------------------------------>>FIELDS<<
    // FIELDS FOR VEHICLE

    //movement
    protected Vector3 acceleration;
    protected Vector3 velocity;
    protected Vector3 desired;

    //public for changing in Inspector
    //define movement behaviors
    public float maxSpeed = 6.0f;
    public float maxForce = 12.0f;
    public float mass = 1.0f;
    public float radius = 1.0f;

    //access to Character Controller component
    CharacterController charControl;


    //Access to GameManager script
    protected GameManager gm;


    // FIELDS FOR SEEKER
    public GameObject seekerTarget;
    public GameObject previousTarget;
    public GameObject avoidTarget;

    // Seeker's steering force (will be added to acceleration)
    private Vector3 force;

    // Weighting
    public float seekWeight = 300.0f;

    public float safeDistance = 25.0f;
    public float avoidWeight = 2000.0f;


    //------------------------------------------------------------------------------>>PROPERTIES<<

    public Vector3 Velocity
    {
        get { return velocity; }
    }

    public GameObject SeekerTarget
    {
        get { return seekerTarget; }
        set { seekerTarget = value; }
    }

    //------------------------------------------------------------------------------>>CONSTRUCTOR<<
    public void Start()
    {
        // Vehicle
        acceleration = Vector3.zero;
        velocity = transform.forward;

        charControl = GetComponent<CharacterController>();
        gm = GameObject.Find("GameManagerGO").GetComponent<GameManager>();

        // Seeker
        force = Vector3.zero;
    }


    //------------------------------------------------------------------------------>>UPDATE
    // Update is called once per frame
    protected void Update()
    {
        //calculate all necessary steering forces
        CalcSteeringForces();

        Vector3 down = new Vector3(0, -1, 0);
        down = down * maxSpeed;

        //add accel to vel
        velocity += acceleration * Time.deltaTime;
        velocity.y = 0; //keeping us on same plane
                        //limit vel to max speed
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        //move the character based on velocity
        charControl.Move(velocity * Time.deltaTime);
        charControl.Move(down * Time.deltaTime);
        //reset acceleration to 0
        acceleration = Vector3.zero;
        transform.forward = velocity.normalized;
    }


    //------------------------------------------------------------------------------>>METHODS<<
    
    protected void CalcSteeringForces()
    {
        force = Vector3.zero;

        // Implement later; to be used to find the nearest exit point
        // seekerTarget = FindNearestExit();

        float dist = Vector3.Distance(transform.position, seekerTarget.transform.position);
        force += Seek(seekerTarget.transform.position) * seekWeight;

        force = Vector3.ClampMagnitude(force, maxForce);
    }

    protected void ApplyForce(Vector3 steeringForce)
    {
        acceleration += steeringForce / mass;
    }
    

    // Seek
    protected Vector3 Seek(Vector3 targetPos)
    {
        desired = targetPos - transform.position;
        desired.y = 0;
        desired = desired.normalized * maxSpeed;
        desired -= velocity;
        return desired;
    }

    // Avoid
    protected Vector3 Avoid(Vector3 targetPos)
    {
        desired = Seek(targetPos);
        return -desired;
    }
}