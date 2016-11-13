﻿using UnityEngine;
using System.Collections;

public class EnemyAIManager : MonoBehaviour {

    public GameObject myPawnTarget;
    public GameObject myKnightTarget;
    Vector3 myPawnPosition;
    Vector3 myKnightPosition;
    public float myCountDown;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        myCountDown -= Time.deltaTime;
        if (myCountDown <= 10)
        {
            myPawnPosition = new Vector3(Random.Range(-20.0f, 20.0f), 0, Random.Range(-20.0f, 20.0f));
            myPawnTarget.transform.position = myPawnPosition;
            myKnightPosition = new Vector3(Random.Range(-20.0f, 20.0f), 0, Random.Range(-20.0f, 20.0f));
            myKnightTarget.transform.position = myKnightPosition;
            myCountDown = 15f;
        }
	}
}