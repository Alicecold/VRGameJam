using UnityEngine;
using System.Collections;

public class GroupManager : MonoBehaviour {

    public float myMovementSpeed;
    public float myDamping;
    public int myUnitID;
    public int myHealth;
    public int myDamage;
    public float myAttackRange;
    public GameObject myTarget;

    public bool myTeam; // True = white, false = black

    public bool myIsMoving;
    public Vector3 myDestination;

    void Start ()
    {
	
	}
	

	void Update ()
    {
        
        myDestination = myTarget.transform.position;
        myDestination.y = 0;
        if ((myDestination - transform.position).magnitude < 1)
        {
            myIsMoving = false;
        }
        else
        {
            Vector3 direction = Vector3.MoveTowards(transform.position, myDestination, Time.fixedDeltaTime * myMovementSpeed);
            transform.position = direction;
            Vector3 lookPos = myDestination - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * myDamping);
        }
    }
}
