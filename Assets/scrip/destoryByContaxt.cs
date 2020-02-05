using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryByContaxt : MonoBehaviour {
    public GameObject bomb;
    public GameObject playerbomb;
    private GameController game;

    // Use this for initialization
    void Start () {

        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if(gameControllerObject != null)
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
        if (other.tag == "border" )
        {
            return;
        }             
                       

        
        if (other.tag == "playership")
        {
            Destroy(gameObject);        //ทำลายตัวเอง
            Destroy(other.gameObject);      //ทำลายของที่ชนด้วย
            Instantiate(playerbomb, other.transform.position, other.transform.rotation); //เกิดเอฟเฟค
            game.GameOver();
        }
           
    }


    

}
