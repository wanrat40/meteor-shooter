using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destorybyBullet : MonoBehaviour {
    public GameObject bomb;
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

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "aster")
        {
            Destroy(gameObject);        //ทำลายตัวเอง
            Destroy(other.gameObject);      //ทำลายของที่ชนด้วย
            Instantiate(bomb, transform.position, transform.rotation);  //เกิดเอฟเฟก
            game.AddScore(1);   //เพิ่มคะแนน
        }

        
        

    }
}
