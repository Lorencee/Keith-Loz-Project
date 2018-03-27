using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followmouse : MonoBehaviour {
    public float CharHeightOffset;
    public Vector3 CursorPos;
    public Vector3 Normal;
    public float range =100;
    public  Transform target;
    float strength = 10f;
    public Transform normal;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // Casts the ray and get the first game object hit
        Physics.Raycast(ray, out hit, range, 1 << LayerMask.NameToLayer("Walkable"));
        //Debug.Log("This hit at " + hit.point);
        CursorPos = new Vector3(hit.point.x, hit.point.y , hit.point.z);

      /*  Vector3 incomingVec = hit.point;
        Vector3 reflectVec = Vector3.Reflect(incomingVec, hit.normal);
       
       

        Debug.Log(hit.point +" " +  reflectVec);

        Vector3 newDir = Vector3.RotateTowards(incomingVec, reflectVec, strength, 1f);

        Debug.DrawLine(hit.point, newDir, Color.green, 2, false);
        Debug.Log(newDir);
        Normal = newDir;

        transform.rotation = Quaternion.LookRotation(normal.position);*/
        transform.position = hit.point;
    }
}
