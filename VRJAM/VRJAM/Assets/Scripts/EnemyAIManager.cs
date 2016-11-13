using UnityEngine;
using System.Collections;

public class EnemyAIManager : MonoBehaviour {

    public GameObject myPawnTarget;
    public GameObject myKnightTarget;
    public GameObject myArcherTarget;
    Vector3 myPawnPosition;
    Vector3 myKnightPosition;
    Vector3 myArcherPosition;
    public float myCountDown;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        myCountDown -= Time.deltaTime;
        if (myCountDown <= 10)
        {
            myPawnPosition = new Vector3(Random.Range(-1000.0f, 2500.0f), 254, Random.Range(-200.0f, -2600.0f));
            myPawnTarget.transform.position = myPawnPosition;
            myKnightPosition = new Vector3(Random.Range(-1000.0f, 2500.0f), 254, Random.Range(-200.0f, -2600.0f));
            myKnightTarget.transform.position = myKnightPosition;
            myArcherPosition = new Vector3(Random.Range(-1000.0f, 2500.0f), 254, Random.Range(-200.0f, -2600.0f));
            myArcherTarget.transform.position = myArcherPosition;
            myCountDown = 15f;
        }
	}
}
