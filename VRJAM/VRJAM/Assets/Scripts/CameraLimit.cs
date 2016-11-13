using UnityEngine;
using System.Collections;

public class CameraLimit : MonoBehaviour
{

    public float myYLimit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(transform.position.y < 0)
        {
            Vector3 position = transform.position;
            position.y = 0;
            transform.position = position;
        }

	}
}
