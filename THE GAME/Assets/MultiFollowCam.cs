using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiFollowCam : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3[] CameraPositions;
    public Quaternion[] CameraRotations;

    public Vector3 offset;
    public Quaternion offsetAngle;
    public float smooth;
    public float minFOV;
    public float maxFOV;
    public float ZoomLimiter;
    float getGreatestDistance;
    private Vector3 velocity;
    private Camera cam;
    public AnimationCurve Zoomcurve;
    int i = 0;
    public float LastRotation;
    public AnimationCurve OffsetZ;
    public AnimationCurve OffsetX;
    public Vector3 MaxBounds;
    public Vector3 MinBounds;
    public float Moveoffset;

    void Start()
    {
        CameraPositions[0] = offset;
        CameraPositions[1] = new Vector3(0,offset.y,-offset.z);
        CameraRotations[0] = offsetAngle;
        CameraRotations[1].x = offsetAngle.x;
        CameraRotations[1].y = -offsetAngle.y;
        CameraRotations[1].z = -offsetAngle.z;
        cam = GetComponent<Camera>();
    }
    void LateUpdate()
    {
        
        if (targets.Count == 0)
        { return; }
        // move();
        //  Zoom();

        Debug.Log(targets[0].eulerAngles.y);

        if (Input.GetButton("Camera Switch") == true)
        {
            float CharRotation = targets[0].eulerAngles.y;
           float Y = CharRotation - LastRotation;

            Mathf.LerpAngle(0, Y, 500 / Time.deltaTime);

            

            // Y *= Mathf.Rad2Deg;
            Debug.Log(Y);
            
            transform.RotateAround(targets[0].position, Vector3.up, Y);
            LastRotation = CharRotation;
        }

        
    }
    void Zoom()
    {
        if (getGreatestDistanceX() >= getGreatestDistanceZ())
        {
            getGreatestDistance = getGreatestDistanceX();
        }
        if (getGreatestDistanceZ() > getGreatestDistanceX())
        {
            getGreatestDistance = getGreatestDistanceZ();
        }
       // Debug.Log(getGreatestDistance);

        float newZoom =Mathf.Clamp(getGreatestDistance*10, minFOV,maxFOV);
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, newZoom, Time.deltaTime);

    }
    float getGreatestDistanceX()
    {

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        bounds.SetMinMax(MinBounds, MaxBounds);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }
    float getGreatestDistanceZ()
    {

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        bounds.SetMinMax(MinBounds, MaxBounds);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.z;
    }
    void move()
    {

        Vector3 centerPoint = GetCenter();
        Vector3 newPos =new Vector3(centerPoint.y + offset.y, Mathf.Clamp(centerPoint.x + offset.x, -Moveoffset, Moveoffset), Mathf.Clamp(centerPoint.z + offset.z, -Moveoffset, Moveoffset));

        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smooth);
    }
    Vector3 GetCenter()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        bounds.SetMinMax(MinBounds,MaxBounds);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
}
