using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject myProjectile;
    private GameObject myTarget;

    public Transform myShootFrom;

    public float myMinForce;
    public float myMaxForce;

    public float myCooldown;

    public float myLifeTime;

    private float myTimer;

    private bool myCanShoot;


    private void Start()
    {
        myCanShoot = false;
    }

    private void FixedUpdate()
    {
        if (myTimer > myCooldown)
        {
            myCanShoot = true;
        }

        myTimer += Time.deltaTime;
    }

    private void OnTriggerStay(Collider aCol)
    {
        if (myCanShoot && aCol.gameObject.tag == "Units")
        {
            float force = Random.Range(myMinForce, myMaxForce);

            GameObject projectile = Instantiate(myProjectile, myShootFrom.transform) as GameObject;
            Rigidbody rigidBody = projectile.GetComponent<Rigidbody>();
            rigidBody.velocity = myShootFrom.transform.forward;
            projectile.GetComponent<Rigidbody>().AddForce(rigidBody.velocity * force);

            Destroy(projectile, myLifeTime);

            myCanShoot = false;
            myTimer = 0;
        }
    }
}
