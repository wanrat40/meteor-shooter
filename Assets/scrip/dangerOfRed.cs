using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dangerOfRed : MonoBehaviour {
    private GameController game;
    public GameObject playerbomb;
    private GameObject player;

    // Use this for initialization
    void Start () {

        player = GameObject.FindWithTag("playership");
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

        if (other.tag == "both") //ถ้ายิงโดนลูกแดง
        {
            game.AddScore(-1); //ยิงลูกแดง ไม่ให้คะแนน            
            Destroy(player);      //ทำลายผู้เล่นทันที
            Instantiate(playerbomb, player.transform.position, player.transform.rotation); //เกิดเอฟเฟค
            game.GameOver();
        }


    }
}
