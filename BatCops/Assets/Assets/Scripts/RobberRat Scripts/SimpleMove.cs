using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour {
	public float speed;
    // Use this for initialization
	public Vector3 startPos;
    public static SimpleMove instance = null;
	public GameObject canvas;

	private Vector3 turn;
	bool newTurn;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
       // DontDestroyOnLoad(gameObject);

		startPos = transform.position;
    }

    void Start () {
		newTurn = false;
		turn = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = transform.position;

		if(Input.GetKey("up") || Input.GetKey(KeyCode.W)){
			newTurn = true;
			newPos = new Vector3(newPos.x,newPos.y,newPos.z+speed);
		}
		if(Input.GetKey("down") || Input.GetKey(KeyCode.S)){
			newTurn = true;
			newPos = new Vector3(newPos.x,newPos.y,newPos.z-speed);
		}
		if(Input.GetKey("left") || Input.GetKey(KeyCode.A)){
			newTurn = true;
			newPos = new Vector3(newPos.x-speed,newPos.y,newPos.z);
		}
		if(Input.GetKey("right") || Input.GetKey(KeyCode.D)){
			newTurn = true;
			newPos = new Vector3(newPos.x+speed,newPos.y,newPos.z);
		}
		if(newTurn){
			turn = newPos-transform.position;
		}
		GetComponent<Rigidbody>().MovePosition(newPos);

		turn.Normalize();
		transform.forward = turn;

	}
}
