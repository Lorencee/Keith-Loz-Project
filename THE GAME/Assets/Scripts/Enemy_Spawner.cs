using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour {

    public GameObject EnemySpawn;
    public int rangeLow;
    public int rangeHigh;
    
    // Use this for initialization
    void Start () {

        int numberOfEnemy = Random.Range(rangeLow, rangeHigh);
        for (int i = 0 ; i <= numberOfEnemy; i++)
        {
            Instantiate(EnemySpawn, gameObject.transform);
        }


    }

	// Update is called once per frame
	void Update () {
		
	}
}
