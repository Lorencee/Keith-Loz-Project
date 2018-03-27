using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TEST : MonoBehaviour {
    public GameObject A, B, O;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 A2, B2;
        A2.x = A.transform.position.x;
        A2.y = A.transform.position.z;
        B2.x = B.transform.position.x;
        B2.y = B.transform.position.z;
        float AngleBetween = Vector2.Angle(A2, B2);
        Debug.Log(AngleBetween);
    }
}
