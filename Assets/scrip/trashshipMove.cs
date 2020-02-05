using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashshipMove : MonoBehaviour {

    public float speed;
   

    void Start()
    {
        gameObject.transform.eulerAngles = new Vector3(
        gameObject.transform.eulerAngles.x,
        gameObject.transform.eulerAngles.y + 180,
        gameObject.transform.eulerAngles.z
        );

        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        
    }

    
}
