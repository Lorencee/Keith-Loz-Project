using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiFollowCam : MonoBehaviour
{
    public List<Transform> targets;

    public Vector3 offset;
    public float smooth;
    public float minFOV;
    public float maxFOV;
    public float ZoomLimiter;
    float getGreatestDistance;
    private Vector3 velocity;
    private Camera cam;
    public AnimationCurve Zoomcurve;

    void Start()
    {
        cam = GetComponent<Camera>();
    }
    void LateUpdate()
    {
        if (targets.Count == 0)
        { return; }
        move();
        Zoom();
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
        Debug.Log(getGreatestDistance);

        float newZoom =Mathf.Clamp(getGreatestDistance*10, minFOV,maxFOV);
        Camera.main.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);

    }
    float getGreatestDistanceX()
    {

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }
    float getGreatestDistanceZ()
    {

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.z;
    }
    void move()
    {

        Vector3 centerPoint = GetCenter();
        Vector3 newPos = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smooth);
    }
    Vector3 GetCenter()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
}
