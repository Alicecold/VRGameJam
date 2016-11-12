using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject myUnit;
    public GameObject myProjectile;
    private GameObject myTarget;

    public Transform myShootFrom;

    public float myMinForce;
    public float myMaxForce;

    public float myCooldown;

    public float myLifeTime;

    private float myTimer;

    private bool myCanShoot;

    bool myShouldLookAtTarget;

    public float myRotationTimeToTarget;


    private void Start()
    {
        myCanShoot = false;
        myShouldLookAtTarget = false;
    }

    private void FixedUpdate()
    {
        if (myTimer > myCooldown)
        {
            myCanShoot = true;
        }

        if (myShouldLookAtTarget == true)
        {
            LookAtTarget();
        }

        myTimer += Time.deltaTime;
    }

    private void LookAtTarget()
    {
        Quaternion rotation = Quaternion.LookRotation(myTarget.transform.position - myUnit.transform.position);
        myUnit.transform.rotation = Quaternion.Slerp(myUnit.transform.rotation, rotation, Time.deltaTime * myRotationTimeToTarget);
    }

    private void OnTriggerStay(Collider aCol)
    {
        if (myCanShoot && aCol.gameObject.tag == "Units")
        {
            myTarget = aCol.gameObject;

            float force = Random.Range(myMinForce, myMaxForce);

            myShouldLookAtTarget = true;

            //GameObject projectile = Instantiate(myProjectile) as GameObject;
            //projectile.transform.position = myShootFrom.transform.position;
            //Rigidbody rigidBody = projectile.GetComponent<Rigidbody>();
            //rigidBody.velocity =  /*myTarget.transform.position - */ myShootFrom.transform.forward;
            //projectile.GetComponent<Rigidbody>().AddForce(rigidBody.velocity * force);

            //Destroy(projectile, myLifeTime);



            //Enemies to point = p  (should not take more than 2 seconds for the enemies to get to the point)
            //Player total seconds to the point should be 3x of how long time it takes for the enemis to reach p
            //Player speed should be 3x faster

            Vector3 targetToPointVector = myTargetPoint - myTarget.transform.position;
            //mySpeed *= 3;

            myCanShoot = false;
            myTimer = 0;
        }
    }

    /*private void OnTriggerExit(Collider aCol)
    {
        //myShouldLookAtTarget = false;
    }*/
}