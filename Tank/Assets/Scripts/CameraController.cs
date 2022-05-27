using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    public Transform tank1, tank2;
    Vector3 offSet;
    Camera cam;
    float camOffset,minDistance;

	// Use this for initialization
	void Start () {
        offSet= transform.position-(tank1.position + tank2.position) / 2;
        cam= GetComponent<Camera>();

        camOffset= cam.orthographicSize/ Vector3.Distance(tank1.position,tank2.position);
        minDistance= Vector3.Distance(tank1.position, tank2.position) / 2;

    }
	
	// Update is called once per frame
	void Update () {
        if (tank1 == null || tank2 == null)
            return;
		transform.position=(tank1.position + tank2.position) / 2+offSet;

      float distance= Vector3.Distance(tank1.position, tank2.position);
        if (distance > minDistance)
        {
            cam.orthographicSize = distance + camOffset;
        }
        
    }
}
