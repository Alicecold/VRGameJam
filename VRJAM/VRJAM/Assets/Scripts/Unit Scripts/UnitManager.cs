using UnityEngine;
using System.Collections;

public class UnitManager : MonoBehaviour
{

    public float myMovementSpeed;
    public float myDamping;
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
            if ((myDestination - transform.position).magnitude < 1)
            {
                myIsMoving = false;
            }
            else
            {
                Vector3 direction = Vector3.Lerp(transform.position, myDestination, Time.deltaTime * myMovementSpeed);
                transform.position = direction;
                Vector3 lookPos = myDestination - transform.position;
                lookPos.y = 0;
                Quaternion rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * myDamping);
            }
        }
        else if (!myIsMoving)
        {
            GameObject targetArea = GameObject.Find("PeasantTarget");
            if ((myDestination - transform.position).magnitude > 1)
            {
                myIsMoving = true;
            }
            else if (myDestination != targetArea.transform.position)
            {
                myDestination = targetArea.transform.position;
            }
            
        }
    }
}

