using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Control : MonoBehaviour {

   
    public float Look_speed;
    public float move_speed;
    public Mousefollow mouse;
    public bool Zoom_Press;
    public bool Zoom_State;
    public float WalkModifier;

    public Transform Cam;
    public Vector3 CamForward;
    public Animator anim;
    Vector3 move;
    Vector3 moveInput;
    public Rigidbody Rigidbod;

    float forwardAmount;
    float turnAmount;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20.0F;

    public GameObject RaycastPos;
    public Ray ray;
    public Vector3 targetPoint;



    public Vector3 Move_speed { get; private set; }

    void Start()
    {
        Zoom_Press = false;
        Zoom_State = false;
    }

    void FixedUpdate()
    {
   
        Zoom_Press = Input.GetButtonDown("Fire1");
        if (Zoom_Press == true)
        {
            if(Zoom_State == false)
            {
               
                Zoom_State = true;
                move_speed = move_speed * WalkModifier;
            }
            else
            {
               
                Zoom_State = false;
                move_speed = move_speed / WalkModifier;
            }

            Debug.Log(Zoom_State);
        }


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        

        // Take input for player Movement

        if (Cam !=null)
        {
            CamForward = Vector3.Scale(Cam.up, new Vector3(1, 0, 1)).normalized;
            move = Input.GetAxis("Vertical") * CamForward + Input.GetAxis("Horizontal") * Cam.right;
        }
        else
        {
            move = Input.GetAxis("Vertical") * Vector3.up + Input.GetAxis("Horizontal") * Vector3.right;
        }
        if (move.magnitude > 1)
        {
            move.Normalize();
        }

        Move(move);

       
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //moveDirection = transform.TransformDirection(moveDirection);
        //Debug.Log(moveDirection);
        moveDirection *= move_speed;

        moveDirection.y -= gravity * Time.deltaTime;
        Rigidbod.AddForce(moveDirection * Time.deltaTime);

        // Generate a plane that intersects the transform's position with an upwards normal.
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        

        // Generate a ray from the cursor position
        Vector3 mousePos;
        mousePos = Input.mousePosition ;
        ray = Camera.main.ScreenPointToRay(mousePos);

        // Determine the point where the cursor ray intersects the plane.
        // This will be the point that the object must look towards to be looking at the mouse.
        // Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
        //   then find the point along that ray that meets that distance.  This will be the point
        //   to look at.
        float hitdist = 0.0f;
        // If the ray is parallel to the plane, Raycast will return false.
        if (playerPlane.Raycast(ray, out hitdist))
        {
            // Get the point along the ray that hits the calculated distance.
            targetPoint = ray.GetPoint(hitdist);

            // Determine the target rotation.  This is the rotation if the transform looks at the target point.
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position );

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Look_speed * Time.deltaTime);
        }



    }
    void Move(Vector3 move)
    {
        if( move.magnitude > 1)
        {
            move.Normalize();
        }

        this.moveInput = move;
        ConverMoveInput();
        UpdateAnimator();

    }

     void ConverMoveInput()
    {
        Vector3 localMove = transform.InverseTransformDirection(moveInput);
       // Debug.Log(localMove);
        turnAmount = localMove.x;
        forwardAmount = localMove.z;
    }

     void UpdateAnimator()
    {
        anim.SetFloat("Vertical", forwardAmount, 1f, Time.deltaTime * 5f);
        anim.SetFloat("Horizontal", turnAmount, 1f, Time.deltaTime * 5f);

    }


}