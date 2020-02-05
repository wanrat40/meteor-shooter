using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour {

    

    public GameObject hazard;
    public GameObject hazard2;
    public GameObject big_hazard;
    public GameObject red_hazard;
    public GameObject trashship;
    public GameObject warning;
    
    private int i;
    public float wait;
    
    public Text StartText;
    public Text GameOverText;
    public Text RestartText;
    public Text ScoreText;
    public Text LevelText;
    public Text CompleteText;
    public Text SpecialText;
    private int point;
    public int level;
    public float Xrange;
    private GameController game;
    AudioSource audioSource;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip flight;
    [SerializeField] AudioClip warn;

    private bool over;
    private bool re;
    // Use this for initialization
    void Start () {

        audioSource = GetComponent<AudioSource>();
        StartCoroutine( Spawn());

        over = false;
        re = false;

        StartText.text = "Level " + level.ToString();
        LevelText.text = "level " + level.ToString();
        GameOverText.text = "";
        RestartText.text = "";
        CompleteText.text = "";

        point = 0;
        UPscore();

        

    }

        
        void UPscore()                      //ฟังก์ชั่นคะแนนในหน้าเกม
            {
                ScoreText.text = "score : " + point.ToString();

            }

    public void AddScore(int newscore)              //ฟังก์ชันเพิ่มคะแนน
            {
                point += newscore;
                UPscore();
                if (point == 10 && level != 10) //คะแนนถึง 10 ส่งเสียง ถ้าไม่ใช่ด่าน10
        {
                        audioSource.PlayOneShot(winSound);
                    }
            }



    public void GameOver() //ฟังก์ชันสถารณะ
    {
        if (point >= 10 && level != 10) // ถ้าชนะแล้วจะไม่ gameover ถ้าไม่ใช่ด่าน10
        {
            return;
        }
        GameOverText.text = "Game Over";
        over = true;


    }

    void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            StartText.text = "";
            SpecialText.text = "";
        }

        if (level == 0)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                SceneManager.LoadScene(1);

            }
        }

        if (point == 10 && level != 10) // ยิงถึง 10 ชนะ
        {            
            CompleteText.text = "Level Complete!!";
            Invoke("LoadNextScene", 2f);
        }

        if (over)
        {
            re = true;
            RestartText.text = "press 'R' to Restart at level 1 \npress 'T' to Restart at same level";
        }

        if (re)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(1);

            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                SceneManager.LoadScene(level);

            }
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(level+1);
    }

    private void DirectAsterio()  //ปล่อยลูกแนวตรง
    {
        Vector3 SpawnPosition = new Vector3(Random.Range(-9, 9), 0.0f, 9.0f);
        Quaternion SpawnRotation = Quaternion.identity;

        Instantiate(hazard, SpawnPosition, SpawnRotation);
    }

    private void ObliqueAsterio()  //ปล่อยลูกแนวเฉียง
    {
        Vector3 SpawnPosition = new Vector3(Random.Range(-6f, 6f), 0.0f, 9.0f);
        Quaternion SpawnRotation = Quaternion.identity;

        Instantiate(hazard2, SpawnPosition, SpawnRotation);
    }

    private void BigAsterio()  //ปล่อยลูกใหญ่แนวตรง
    {
        Vector3 SpawnPosition = new Vector3(Random.Range(-9, 9), 0.0f, 9.0f);
        Quaternion SpawnRotation = Quaternion.identity;

        Instantiate(big_hazard, SpawnPosition, SpawnRotation);
    }

    private void RedAsterio()  //ปล่อยลูกแดง
    {
        Vector3 SpawnPosition = new Vector3(Random.Range(-9, 9), 0.0f, 9.0f);
        Quaternion SpawnRotation = Quaternion.identity;

        Instantiate(red_hazard, SpawnPosition, SpawnRotation);
    }

    private void TrashShip()  //ปล่อยซากจรวด
    {        
        Vector3 SpawnPosition = new Vector3(Xrange, 0.0f, 9.0f);       

        Quaternion SpawnRotation = Quaternion.identity;        
        audioSource.PlayOneShot(flight);
        Instantiate(trashship, SpawnPosition, SpawnRotation);
    }

    private void WarningSign()  //ปล่อยสัญลักษณ์เตือน
    {        
        GameObject player = GameObject.FindWithTag("playership");
        Xrange = player.transform.position.x; // เอา X จากตำแหน่งผู้เล่น
        audioSource.PlayOneShot(warn); // เล่นเสียงเตือน

        Vector3 SpawnPosition = new Vector3(Xrange, -4.0f, 7.0f);
        Quaternion SpawnRotation = Quaternion.Euler(-33f, 89f, -87f);
        Instantiate(warning, SpawnPosition, SpawnRotation);
    }

    private void DestroyWarning()
    {
        Destroy(GameObject.FindWithTag("warning"));
    }

    IEnumerator Spawn()
    {
        switch (level)  //ลักษณะการปล่อยอุกกาบาต ตามเลเวล
        {
            case 1:  //ด่าน 1 ลูกแนวตรง
                while(true)
                        {

                            DirectAsterio();
                            yield return new WaitForSeconds(wait);    //คำสั่งรอเวลา ใช้กับ ienumerator กับ StartCoroutine

                        }
                break;

            case 2: //ด่าน 2 ลูกแนวเฉียง
                while (true)
                        {

                            ObliqueAsterio();
                            yield return new WaitForSeconds(wait);    

                        }
                break;

            case 3:  //ด่าน 3 ลูกแนวตรง&เฉียง
                while (true)
                    {                                          
                        
                        int num = Random.Range(0,2); //สุ่มปล่อยตรงกับเฉียง

                        if(num == 0)
                        DirectAsterio();

                        else
                        ObliqueAsterio();

                        yield return new WaitForSeconds(wait);

                    }
                break;

            case 4:  //ด่าน 4 ลูกใหญ่ตรง
                while (true)
                    {

                        BigAsterio();

                        yield return new WaitForSeconds(wait);   

                    }
                break;

            case 5:  //ด่าน 5 ลูกใหญ่ตรง&ลูกเฉียง
                while (true)
                {

                    BigAsterio();
                    Invoke("ObliqueAsterio", 0.5f);

                    yield return new WaitForSeconds(wait);    

                }
                break;

            case 6:  //ด่าน 6 ลูกแดง&ลูกเฉียง
                i = 0;
                while (true)
                {
                    i++;
                    ObliqueAsterio();
                    if(i%3==0)   //ปล่อยลูกแดงเมื่อ i หาร 3 ลงตัว
                    RedAsterio();

                    yield return new WaitForSeconds(wait);    

                }
                break;

            case 7:  //ด่าน 7 ลูกตรง&ลูกเฉียง&ลูกแดง
                i = 0;
                while (true)
                {
                    i++;
                    int num = Random.Range(0, 2);

                    if (num == 0)
                        DirectAsterio();

                    else
                        ObliqueAsterio();

                    if (i % 2 == 0)   //ปล่อยลูกแดงเมื่อ i หาร 3 ลงตัว
                        RedAsterio();

                    yield return new WaitForSeconds(wait);

                }
                break;

            case 8:  //ด่าน 8 ลูกตรง&จรวดชน
                i = 0;
                while (true)
                {
                    i++;
                    DirectAsterio();

                    if (i % 5 == 0)   //ส่งจรวดทุก5ลูก
                    {                      
                        WarningSign(); //ปล่อยสัญลักษณ์เตือนก่อน

                        Invoke("DestroyWarning", 1.5f);  //ทำลายสัญลักษณ์เตือนใน 1.5 วิ
                        Invoke("TrashShip", 1.8f); //ปล่อยซากจรวด
                    }            

                    yield return new WaitForSeconds(wait);

                }
                break;

            case 9:  //ด่าน 9 ลูกใหญ่&ลูกตรง&จรวดชน
                i = 0;
                while (true)
                {
                    i++;
                    DirectAsterio();
                    Invoke("BigAsterio", 1.5f);
                    if (i % 5 == 0)   //ส่งจรวดทุก5ลูก
                    {
                        WarningSign(); //ปล่อยสัญลักษณ์เตือนก่อน

                        Invoke("DestroyWarning", 1.5f);  //ทำลายสัญลักษณ์เตือนใน 1.5 วิ
                        Invoke("TrashShip", 1.8f); //ปล่อยซากจรวด
                    }

                    yield return new WaitForSeconds(wait);

                }
                break;

            case 10:  //ด่าน 10 ลูกใหญ่&ลูกเฉียง&ลูกแดง&จรวดชน
                i = 0;
                while (true)
                {
                    i++;
                    ObliqueAsterio();
                    Invoke("BigAsterio", 1.5f);

                    if (i % 3 == 0)   
                    {
                        RedAsterio();
                    }

                    if (i % 4 == 0)   //ส่งจรวดทุก4ลูก
                    {
                        WarningSign(); //ปล่อยสัญลักษณ์เตือนก่อน
                        Invoke("DestroyWarning", 1.5f);  //ทำลายสัญลักษณ์เตือนใน 1.5 วิ
                        Invoke("TrashShip", 1.8f); //ปล่อยซากจรวด
                        
                    }

                    yield return new WaitForSeconds(wait);

                }
                break;

        }
        

               

    }

    

    
}
