using UnityEngine;
using System.Collections;

public class MovementManager : MonoBehaviour {

    public Vector3 myPosition;
    public float myX;

	// Use this for initialization
	void Start ()
    {
        
	}

    void Update ()
    {
        myPosition = transform.position;

    }
}
