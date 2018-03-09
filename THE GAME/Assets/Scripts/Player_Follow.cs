using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Follow : MonoBehaviour
{

    public float smooth;
    public float zoomOutFOV;
    public float zoomInFOV;
    public Camera PlayerCam;

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

        offsetX = PlayerCam.transform.position.x - transform.position.x;
        offsetY = PlayerCam.transform.position.y - transform.position.y;
        offsetZ = PlayerCam.transform.position.z - transform.position.z;

        CharX = transform.position.x;
        CharY = transform.position.y;
        CharZ = transform.position.z;

        zoomState = ZoomState.Zoom_State;
        zoomInFOV = PlayerCam.fieldOfView;


    }

    // Update is called once per frame
    void LateUpdate()
    {

        currentFOV = PlayerCam.fieldOfView;
        PlayerCam.transform.rotation = Quaternion.Euler(90, 0, 0);


        if (zoomState == true)
        {
            if (currentFOV != zoomOutFOV)
            {

                if (currentFOV < zoomOutFOV)
                {
                    PlayerCam.fieldOfView -= (-smooth * Time.deltaTime);
                }
                else
                {
                    if (currentFOV >= zoomOutFOV)
                    {
                        PlayerCam.fieldOfView = zoomOutFOV;
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
                    PlayerCam.fieldOfView += (-smooth * Time.deltaTime);
                }
                else
                {

                    if (currentFOV <= zoomInFOV)
                    {
                        PlayerCam.fieldOfView = zoomInFOV;
                    }
                }
            }
        }

        zoomState = ZoomState.Zoom_State;

        Char.x = transform.position.x /*+ offsetX*/;
        Char.y = transform.position.y + offsetY;
        Char.z = transform.position.z /*+ offsetZ*/;

        Debug.Log(offsetY);
        float centreY = transform.position.y - transform.position.y;

        PlayerCam.transform.position = Char;


    }
}
