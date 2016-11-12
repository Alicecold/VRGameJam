using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject myProjectile;
    public Transform myShootFrom;

    /*public float myCooldDown;
    private float myTimer;


    private void Start()
    {
        myTimer = 0;
    }*/

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Instantiate(myProjectile, myShootFrom.position, Quaternion.identity);
        }
    }
}
