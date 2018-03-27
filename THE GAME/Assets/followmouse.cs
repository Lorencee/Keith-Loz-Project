using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followmouse : MonoBehaviour {
    public float CharHeightOffset;
    public Vector3 CursorPos;
    public float range =100;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // Casts the ray and get the first game object hit
        Physics.Raycast(ray, out hit, range, 1 << LayerMask.NameToLayer("Walkable"));
        Debug.Log("This hit at " + hit.point);
        CursorPos = new Vector3(hit.point.x, hit.point.y , hit.point.z);

        transform.position = hit.point;
    }
}
