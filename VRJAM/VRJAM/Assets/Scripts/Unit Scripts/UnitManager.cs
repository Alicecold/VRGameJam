using UnityEngine;
using System.Collections;

public class UnitManager : MonoBehaviour
{

    public float myMovementSpeed;
    public float myDamping;
    public int myUnitID;
    public int myHealth;
    public int myDamage;
    public float myAttackRange;

    public bool myTeam; // True = white, false = black
    bool myIsMoving;
    Vector3 myDestination;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ()
        {

        }

        GameObject targetArea = GameObject.Find("Target");
        myDestination = targetArea.transform.position;
        myDestination.y = 0;
        if ((myDestination - transform.position).magnitude < 1)
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

