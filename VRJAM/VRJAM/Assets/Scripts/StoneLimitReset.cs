using UnityEngine;
using System.Collections;

public class StoneLimitReset : MonoBehaviour {

    public GameObject myRespawnPoint;
    public BoxCollider myBoundaries;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {  
	    if(myBoundaries.bounds.Contains(transform.position) == false)
        {
            transform.position = myRespawnPoint.transform.position;
        }
	}
}
