using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour {
    private Rigidbody A;  //ตัวแปลเคลื่อนที่
    public float speed;
    public GameObject bullet;
    public Transform shootspawn;
    public float firerate;
    private float nextshot;
    

    // Use this for initialization
    void Start () {

        A = GetComponent<Rigidbody>();      //ตัวแปรที่แทนวัตถุต้องการให้เคลื่อนไหว
        

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");   //รับค่าเคลื่อนย้ายในแกน X
        float moveVertical = Input.GetAxis("Vertical");      //รับค่าเคลื่อนย้ายในแกน Z

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);   //รับค่าการเคลื่อนไหวใส่ใน movement ในรูปแบบ vector3มิติ
        A.velocity = (movement * speed);  //ค่าการเคลื่อนไหวของ movement กลายเป็นตำแหน่งใหม่ของวัตถุ
        //กำหนดจุดสูงสุดต่ำสุด

        A.position = new Vector3(Mathf.Clamp(A.position.x, -11, 11),
            0.0f,
            Mathf.Clamp(A.position.y, -1, 7)
            );

        //A.rotation = Quaternion.Euler(0.0f, 0.0f, A.velocity.x*5);  //ตัวเอียง

        
    }


    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextshot)
        {
            nextshot = Time.time + firerate;
            Instantiate(bullet, shootspawn.position, shootspawn.rotation); //เพิ่มกระสุน
            GetComponent<AudioSource>().Play();
        }

    }
    
}
