using UnityEngine;
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
    private GameObject myTarget;

    void Start()
    {
        GroupManager InitSettings = transform.parent.gameObject.GetComponent<GroupManager>();
        myMovementSpeed = InitSettings.myMovementSpeed - 0.01f;
        myDamping = InitSettings.myDamping;
        myUnitID = InitSettings.myUnitID;
        myHealth = InitSettings.myHealth;
        myDamage = InitSettings.myDamage;
        myAttackRange = InitSettings.myAttackRange;

        myTeam = InitSettings.myTeam;
        myTarget = InitSettings.myTarget;
      }

    void Update()
    {
        myDestination = myTarget.transform.localToWorldMatrix.GetPosition();
        myDestination.y = 0;
        Vector3 position = transform.position;
        position.y = 0;

        if ((myDestination - position).magnitude < 1.0)
        {
            myIsMoving = false;
        }
        else
        {
            Vector3 direction = Vector3.Lerp(position, myDestination, Time.fixedDeltaTime * myMovementSpeed);
            transform.position = direction;
            Vector3 lookPos = myDestination - position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * myDamping);
        }
    }
}

