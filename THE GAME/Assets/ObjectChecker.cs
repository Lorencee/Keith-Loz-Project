using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class ObjectChecker : NetworkBehaviour {

    // Update is called once per frame
    void Update () {
        Debug.Log(gameObject.name + "= Loaded");
		
	}
}
