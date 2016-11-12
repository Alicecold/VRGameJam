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

            GameObject projectile = Instantiate(myProjectile) as GameObject;
            projectile.transform.position = myShootFrom.transform.position;
            Rigidbody rigidBody = projectile.GetComponent<Rigidbody>();
            rigidBody.velocity = myShootFrom.transform.forward;
            projectile.GetComponent<Rigidbody>().AddForce(rigidBody.velocity * force);

            Destroy(projectile, myLifeTime);

            myCanShoot = false;
            myTimer = 0;
        }
    }

    /*private void OnTriggerExit(Collider aCol)
    {
        //myShouldLookAtTarget = false;
    }*/
}