using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public GameObject myAir;
    public float mySpeed;

	void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(myAir.gameObject.transform.forward * mySpeed);
    }
}
