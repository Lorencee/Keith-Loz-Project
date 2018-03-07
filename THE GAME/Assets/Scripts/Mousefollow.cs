using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousefollow : MonoBehaviour {



    Vector3 MousePosition;
    public Character_Control CharLook;
    // Use this for initialization
    void Start () {
        MousePosition = CharLook.targetPoint;
        transform.position = MousePosition;
       

        Cursor.visible = false;
        

    }
	
	// Update is called once per frame
	void Update () {

        MousePosition = CharLook.targetPoint;
        transform.position= MousePosition;
		
	}
}
