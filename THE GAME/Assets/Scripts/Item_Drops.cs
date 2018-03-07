using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Drops : MonoBehaviour {

    // Use this for initialization
    public Enemy Character;
    public GameObject DropAk47;
    public GameObject LootRingLegendary;
    public bool finished;
    public float DropPosX;
    public float DropPosY;
    public float DropPosZ;
    public Vector3 DropPos;

    void Start () {

        finished = false;

    }
	
	// Update is called once per frame
	void Update () {
		  if (Character.Alive == false)
        {
            Drop();
        }
	}

    public void Drop ()
    {
        DropPosX = Character.diePos.x;
        DropPosY = Character.diePos.y -10;
        DropPosZ = Character.diePos.z;
        
        Character.Alive = true;

        Debug.Log("itemDropped");
        Instantiate(DropAk47, Character.diePos, Quaternion.identity);
        Character.diePos.y += 5;
        Instantiate(LootRingLegendary, Character.diePos, Quaternion.Euler(90,0,0));
        finished = true;

    }

}
