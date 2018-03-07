using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hud_info : MonoBehaviour {

    public GunScript Gun;
    public TextMeshProUGUI Text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       Text= GetComponent<TextMeshProUGUI>() ?? gameObject.AddComponent<TextMeshProUGUI>();

        Text.text = "Ammo " + Gun.Ammo.ToString();

        Debug.Log("");
        

	}
}
