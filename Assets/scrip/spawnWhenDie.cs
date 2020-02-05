using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnWhenDie : MonoBehaviour {
    public GameObject hazard2;
    private GameController game;
    // Use this for initialization
    void Start () {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            game = gameControllerObject.GetComponent<GameController>();

        }

        if (gameControllerObject == null)
        {
            Debug.Log("cannot find");
        }
    }	
	

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "both")
        {
            //game.AddScore(-1); //ยิงลูกใหญ่ ยังไม่ให้คะแนน
            Vector3 SpawnPosition = transform.position;  //เก็บตำแหน่งปัจจุบัน
            Quaternion SpawnRotation = Quaternion.identity;

            Instantiate(hazard2, SpawnPosition, SpawnRotation);
            Instantiate(hazard2, SpawnPosition, SpawnRotation);
        }
        

    }

}
