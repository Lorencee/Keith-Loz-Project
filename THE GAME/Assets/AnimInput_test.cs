﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimInput_test : MonoBehaviour {

    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal") ;
        float v = Input.GetAxis("Vertical") ;
        bool fire = Input.GetButtonDown("Fire1");

        animator.SetFloat("Vertical", v, 1f, Time.deltaTime * 5f) ;
        animator.SetFloat("Horizontal", h, 1f, Time.deltaTime * 5f);

    }

}

