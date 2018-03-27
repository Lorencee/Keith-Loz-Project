using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tranform : MonoBehaviour {
    public followmouse normal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = normal.Normal;
		
	}
}
