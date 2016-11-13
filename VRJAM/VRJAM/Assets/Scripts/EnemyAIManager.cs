using UnityEngine;
using System.Collections;

public class EnemyAIManager : MonoBehaviour
{

    public GameObject myPawnTarget;
    public GameObject myKnightTarget;
    public GameObject myArcherTarget;
    Vector3 myPawnPosition;
    Vector3 myKnightPosition;
    Vector3 myArcherPosition;
    public float myCountDown;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        myCountDown -= Time.deltaTime;
        if (myCountDown <= 10)
        {
            if (myPawnTarget != null)
            {
                myPawnTarget.GetComponent<Rigidbody>().AddForce(transform.forward * 4000.0f);
            }

            if (myKnightTarget != null)
            {
                myKnightTarget.GetComponent<Rigidbody>().AddForce(transform.forward * 4000.0f);
            }

            if (myArcherTarget != null)
            {
                myArcherTarget.GetComponent<Rigidbody>().AddForce(transform.forward * 4000.0f);
            }
            
            //myPawnPosition = new Vector3(Random.Range(-20.0f, 20.0f), 0, Random.Range(-20.0f, 20.0f));
            //myPawnTarget.transform.position = myPawnPosition;
            // myKnightPosition = new Vector3(Random.Range(-20.0f, 20.0f), 0, Random.Range(-20.0f, 20.0f));
            //myKnightTarget.transform.position = myKnightPosition;
            //myArcherPosition = new Vector3(Random.Range(-20.0f, 20.0f), 0, Random.Range(-20.0f, 20.0f));
            //myArcherTarget.transform.position = myKnightPosition;
            myCountDown = 18f;
        }
    }
}
