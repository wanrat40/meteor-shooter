using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class out_of_map : MonoBehaviour {

	void OnTriggerExit(Collider other)
    {

        Destroy(other.gameObject);
    }
}
