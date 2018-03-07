using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Follow : MonoBehaviour
{

    public float smooth;
    public float zoomOutFOV;
    public float zoomInFOV;

    public Character_Control ZoomState;
    private float offsetX;
    private float offsetY;
    private float offsetZ;
    private Vector3 Char;
    private float CharX;
    private float CharY;
    private float CharZ;
    private float currentFOV;


    bool zoomState;




    // Use this for initialization
    void Start()
    {

        offsetX = Camera.main.transform.position.x - transform.position.x;
        offsetY = Camera.main.transform.position.y - transform.position.y;
        offsetZ = Camera.main.transform.position.z - transform.position.z;

        CharX = transform.position.x;
        CharY = transform.position.y;
        CharZ = transform.position.z;

        zoomState = ZoomState.Zoom_State;
        zoomInFOV = Camera.main.fieldOfView;


    }

    // Update is called once per frame
    void LateUpdate()
    {

        currentFOV = Camera.main.fieldOfView;
        Camera.main.transform.rotation = Quaternion.Euler(90, 0, 0);


        if (zoomState == true)
        {
            if (currentFOV != zoomOutFOV)
            {

                if (currentFOV < zoomOutFOV)
                {
                    Camera.main.fieldOfView -= (-smooth * Time.deltaTime);
                }
                else
                {
                    if (currentFOV >= zoomOutFOV)
                    {
                        Camera.main.fieldOfView = zoomOutFOV;
                    }
                }
            }
        }

        if (zoomState == false)
        {
            if (currentFOV != zoomInFOV)
            {

                if (currentFOV > zoomInFOV)
                {
                    Camera.main.fieldOfView += (-smooth * Time.deltaTime);
                }
                else
                {

                    if (currentFOV <= zoomInFOV)
                    {
                        Camera.main.fieldOfView = zoomInFOV;
                    }
                }
            }
        }

        zoomState = ZoomState.Zoom_State;

        Char.x = transform.position.x /*+ offsetX*/;
        Char.y = transform.position.y + offsetY;
        Char.z = transform.position.z /*+ offsetZ*/;


        float centreY = transform.position.y - transform.position.y;

        Camera.main.transform.position = Char;


    }
}
