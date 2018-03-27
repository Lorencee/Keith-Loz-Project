using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousefollow : MonoBehaviour
{

    public GameObject RaycastPos;
    public GameObject Char;


    Vector3 MousePosition;

    Vector3 Offset;
    // Use this for initialization
    void Start()
    {
        MousePosition = Input.mousePosition;
        Cursor.visible = false;
        //Debug.Log(RaycastPos.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(RaycastPos.transform.position);

        MousePosition = Input.mousePosition;


        transform.position = MousePosition;

    }
}
