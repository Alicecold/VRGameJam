﻿using UnityEngine;
using System.Collections;

public class UnitManager : MonoBehaviour
{
    private float myMovementSpeed;
    private float myDamping;
    private int myUnitID;
    private int myHealth;
    private int myDamage;
    private float myAttackRange;

    private bool myTeam; // True = white, false = black
    private bool myIsMoving;
    private Vector3 myDestination;

    void Start()
    {
        GroupManager InitSettings = transform.parent.gameObject.GetComponent<GroupManager>();
        myMovementSpeed = InitSettings.myMovementSpeed;
        myDamping = InitSettings.myDamping;
        myUnitID = InitSettings.myUnitID;
        myHealth = InitSettings.myHealth;
        myDamage = InitSettings.myDamage;
        myAttackRange = InitSettings.myAttackRange;

        myTeam = InitSettings.myTeam;
      }

    void Update()
    {
        GameObject myParent = transform.parent.gameObject;
        myDestination = myParent.transform.position;
        myDestination.y = 0;
        if ((myDestination - transform.position).magnitude < .3)
        {
            myIsMoving = false;
        }
        else
        {
            Vector3 direction = Vector3.Lerp(transform.position, myDestination, Time.fixedDeltaTime * myMovementSpeed);
            transform.position = direction;
            Vector3 lookPos = myDestination - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * myDamping);
        }
    }
}

