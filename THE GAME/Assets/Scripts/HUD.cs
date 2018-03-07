using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class HUD : MonoBehaviour
{

    public GunScript Gun;
    public TextMeshProUGUI Text;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        Text.text = "Ammo: " +  Gun.Ammo.ToString();



    }
}
