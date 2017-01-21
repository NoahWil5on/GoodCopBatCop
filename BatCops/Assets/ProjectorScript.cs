using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorScript : MonoBehaviour {

    bool up = true, powered = false;
    float poweredTime, poweredTimeStart = 0;
    Projector myProj;
	// Use this for initialization
	void Start () {
        myProj = GetComponent<Projector>();
	}
	
	// Update is called once per frame
	void Update () {
        if (powered)
        {
            if (up)
            {
                myProj.orthographicSize += 0.05f;

                if (myProj.orthographicSize >= poweredTime)
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
        }else
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
