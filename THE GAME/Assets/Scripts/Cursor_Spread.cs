﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Spread : MonoBehaviour {
    public Accuracy Acc;
    public bool Vertical;
    public bool Positive;
    public float VertMin;
    public float Accuracy;

	// Use this for initialization
	void Start () {



    }
	
	// Update is called once per frame
	void Update () {

        Accuracy = 990 - Acc.AccuracyVal * 1000;

        

        if (Vertical == true)
        {
            if (Positive == true)
            {
               transform.localPosition = new Vector3(0, Accuracy, 0);

            }
            else
            {
                transform.localPosition = new Vector3(0, -Accuracy, 0);
            }

        }
        else
            if (Positive == true)
            {
                transform.localPosition = new Vector3(Accuracy, 0, 0);

            }
            else
            {
                transform.localPosition = new Vector3(-Accuracy, 0, 0);
            }
    }
}
