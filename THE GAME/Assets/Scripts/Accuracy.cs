using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accuracy : MonoBehaviour {
    public float Max_Accuracy;
    public float Min_Accuracy;
    public float initMinAccuracy;
    public float KickBack;
    public float RecoveryMax;
    public float RecoveryMin;
    public float Recovery;

    private float MaxMinAccuracy;
    public float RecoveryCurvePOS;
    public AnimationCurve RecoveryCurve;
    public Character_Control ZoomState;
    public float ZoomAccuracyModifier;


    public float AccuracyVal;
    [Range(0,1)]
    public float i;
    public GunScript Shoot;

    private float LastFireTime;


    



	// Use this for initialization
	void Start () {
        

        i = Max_Accuracy;
        RecoveryCurvePOS = 0f;
        initMinAccuracy = Min_Accuracy;
        MaxMinAccuracy = Min_Accuracy + ZoomAccuracyModifier;

    }
	
	// Update is called once per frame
	void Update () {
        
        
        if (ZoomState.Zoom_State == true)
        {
            Min_Accuracy = MaxMinAccuracy; 
        }
        else
        {
            Min_Accuracy = initMinAccuracy;
        }

        Recovery = RecoveryCurve.Evaluate(RecoveryCurvePOS);
        AccuracyVal = Mathf.Clamp(i, Min_Accuracy, Max_Accuracy);
      
        if(Shoot.isFiring == true)
        {
            RecoveryCurvePOS = 0;

            if(i>Min_Accuracy)
            {
                i -= KickBack;
                
            }

            LastFireTime = Time.time;
        }

        if (Shoot.isFiring == false)
        {
            RecoveryCurvePOS = Mathf.Lerp(0, 1, (Time.time - LastFireTime ));

            

            if (i < Max_Accuracy)
            {
                
                i += Recovery;
            }
           
        }
        if (i > 1) { i = 1; }

        

    }
}
