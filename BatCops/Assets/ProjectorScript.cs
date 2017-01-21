using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorScript : MonoBehaviour {

    bool up = true, powered = false;
    float poweredTime, poweredTimeStart = 0;
    Projector myProj;

    public static ProjectorScript instance = null;              

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
        DontDestroyOnLoad(gameObject);


    }

    
    // Use this for initialization
    void Start () {
        myProj = GetComponent<Projector>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 vec3 = new Vector3(SimpleMove.instance.transform.position.x, 7, SimpleMove.instance.transform.position.z);
        transform.position = vec3;
        if (powered)
        {
            if (up)
            {
                myProj.orthographicSize += 0.05f;
                
                Collider[] cols = Physics.OverlapCapsule(SimpleMove.instance.transform.position, transform.position, myProj.orthographicSize, 1 << LayerMask.NameToLayer("Enemy")| 1 <<  LayerMask.NameToLayer("Walls"));
                foreach(Collider col in cols)
                {
                    col.gameObject.GetComponent<EnemyFlash>().Temp();
                    Debug.Log(col.gameObject.name);
                }
                if (myProj.orthographicSize >= poweredTime*1.5f)
                {
                    up = false;
                }
            }
            else
            {
                myProj.orthographicSize -= 0.05f;

                if (myProj.orthographicSize <= 1)
                {
                    up = true;
                    powered = false;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                
                poweredTimeStart = Time.time;
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                poweredTime = Time.time - poweredTime;
                if (poweredTime > 3)
                    poweredTime = 3;
                powered = true;
            }

        }

    }
}
