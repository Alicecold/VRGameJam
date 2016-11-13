using UnityEngine;

public class Shoot : MonoBehaviour
{
    public string myAttackEnemyTag;

    public GameObject myUnit;
    public GameObject myProjectile;

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
        //Quaternion rotation = Quaternion.LookRotation(myTarget.transform.position - myUnit.transform.position);
        //myUnit.transform.rotation = Quaternion.Slerp(myUnit.transform.rotation, rotation, Time.deltaTime * myRotationTimeToTarget);
    }

    private void OnTriggerStay(Collider aCol)
    {
        if (myCanShoot && aCol.gameObject.tag == myAttackEnemyTag)
        {
            myShouldLookAtTarget = true;

            GameObject projectile = Instantiate(myProjectile) as GameObject;
            projectile.transform.position = myShootFrom.transform.position;
            Rigidbody rigidBody = projectile.GetComponent<Rigidbody>();
            rigidBody.velocity = myShootFrom.transform.forward;
            projectile.GetComponent<Rigidbody>().AddForce(rigidBody.velocity * Random.Range(740, 770));

            Destroy(projectile, myLifeTime);

            myCanShoot = false;
            myTimer = 0;
        }
    }
}