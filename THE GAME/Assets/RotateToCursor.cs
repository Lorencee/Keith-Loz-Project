using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateToCursor : MonoBehaviour {

    public Transform target;

    // The target marker.
    

    // Angular speed in radians per sec.
   public float speed;


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        Vector3 targetDir = target.position - transform.position;

        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        Debug.Log(transform.position + newDir);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
