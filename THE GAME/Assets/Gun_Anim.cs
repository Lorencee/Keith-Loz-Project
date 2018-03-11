using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Anim : MonoBehaviour
{
    public Animator anim;
    public GunScript Gun;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Gun.isFiring == true)
        {



            shoot();


        }
    }
    void shoot()
    {
        
        anim.SetBool("Recoil", true);
        anim.SetFloat("RecoilRandomizer", Random.value);
        Invoke("StopShoot", 0.025f);
    }
    void StopShoot()
    {
        anim.SetBool("Recoil", false);
    }
}
