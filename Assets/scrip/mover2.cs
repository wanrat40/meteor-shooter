using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover2 : MonoBehaviour {

    public float speed;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(Random.Range(-2, 2), 0f, Random.Range(-3, 0))*speed;
    }
	
	
}
