using UnityEngine;
using System.Collections;

public class UnitManager : MonoBehaviour
{

    public float myMovementSpeed;
    public int myUnitID;
    public int myHealth;
    public int mySpeed;
    public int myDamage;
    public bool myIsRanged;

    public bool myIsMoving;
    public Vector3 myDestination;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (myIsMoving)
        {
            if ((myDestination - transform.position).magnitude < 0.5)
            {
                myIsMoving = false;
            }
            else
            {
                Vector3 direction = Vector3.Lerp(transform.position, myDestination, Time.time * myMovementSpeed);
                transform.position = direction;
            }
        }
        else if (!myIsMoving)
        {
            if ((myDestination - transform.position).magnitude > 0.5)
            {
                myIsMoving = true;
            }
        }
    }
}

