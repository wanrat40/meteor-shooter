using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere*8;

    }
	
	
}
