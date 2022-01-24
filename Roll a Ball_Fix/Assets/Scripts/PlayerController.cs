using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//벽에 플레이어가 다가각면 벽을 안보이게(불투명하게) 만들기.
//맵 중간에 사물 배치하기, 플레이어의 가속도가 눈에 보이게.

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public int speed;
    public int jump;
    private int score = 0;
    public int Max_Score = 6;
    public TextMeshProUGUI countScore; //TextMeshPro 레퍼런스
    public GameObject WinTextObject;
    public GameObject LoseTextObject;

    private AudioSource audioPoint;
    private AudioSource audioWin;
    private AudioSource audioLose;
    public AudioClip pointsound;
    public AudioClip Winsound;
    public AudioClip Losesound;


    bool fly = false;   //플레이어가 현재 점프해있는지를 확인하는 변수이다.
    float fly_time = 2f;   //다시 점프하기 까지 시간
    float flytimer = 0f;    //점프 타이머

    bool booster = false;  //플레이어가 현재 스피드 아이템을 먹은 상태인지 체크 
    float speedtime = 3f;  //3초 동안 플레이어를 빠르게 만들어준다.
    float speedtimer = 0f; //스피드타이머
    bool startgame = false; //게임 시작을 했는지 안했는지



    Rigidbody rb;       //리지드바디
    float horizontal;   //수평축 값
    float vertical;    //수직축값
    Vector3 movement; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        audioPoint = gameObject.AddComponent<AudioSource>();
        audioWin = gameObject.AddComponent<AudioSource>();
        audioLose = gameObject.AddComponent<AudioSource>();

        audioPoint.clip = pointsound;
        audioWin.clip = Winsound;
        audioLose.clip = Losesound;

        audioPoint.loop = false;
        audioWin.loop = false;
        audioLose.loop = false;



        WinTextObject.SetActive(false); //게임이 이겼다는 텍스트는 시작시에 비활성화 시킨다.
        LoseTextObject.SetActive(false);


        Time.timeScale = 0; //처음엔 일시정지 상태이다.
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       horizontal =  Input.GetAxis("Horizontal"); 
       vertical = Input.GetAxis("Vertical");

        movement = new Vector3(horizontal, 0, vertical);

        rb.AddForce(movement*speed);

    }

    void Update()
    {
        countScore.text = score.ToString() + " / " + Max_Score.ToString(); //현재 몇개의 점수를 먹었는지를 보여준다.

        if (startgame == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                startgame = true;
                Time.timeScale = 1;
            }
            
        }
      
        //SetCountText();
        Debug.Log(score);
        if (fly == true)  //비행 상태가 참이면 
        {
            flytimer += Time.deltaTime;  //Time.deltaTime을 더한다는건 1을 더한다는거랑 똑같다. 
        }
        if(booster==true)
        {
            speedtimer += Time.deltaTime;
        }
       
        if(flytimer >= fly_time)
        {
            fly = false;
            flytimer = 0;
        }
        if(speedtimer >= speedtime)
        {
            booster = false;
            speedtimer = 0;
            speed -= 5;
        }

        if (Input.GetKeyDown(KeyCode.Space) && fly == false)
        {
            movement = new Vector3(horizontal, 1, vertical);
            rb.AddForce(movement * jump);
            fly = true;                   //비행 상태 TRUE
        }
        
         if(Time.timeScale == 0 )
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                startgame = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                //GetActiveScene().name을 통해 현재 씬의 이름을 받아온다.
                //LoadScene을 통해 해당 scene을 실행한다.
            }
        }
    }

    private void OnCollisionEnter(Collision collision) //콜라이전 함수
    {

       if(collision.gameObject.CompareTag("Enemy"))
        {
            LoseTextObject.SetActive(true);
            audioLose.Play();
            Time.timeScale = 0; //timeScale의 기본값은 1이다.  

               


        }
    }

    
private void OnTriggerEnter(Collider other) //트리거 함수 
    {
        if(other.gameObject.CompareTag("Point"))
        {
            score++;
            audioPoint.Play();

            if (score == Max_Score)  //score이 max score이 되면 이겼다는 음성과 함께 Win text를 활성화시킨다. 게임 일시정지
            {

                audioWin.Play();
                WinTextObject.SetActive(true);
                Time.timeScale = 0; //timeScale의 기본값은 1이다.  


            }

            other.gameObject.SetActive(false);  //먹은 point 변수 없애기
        }
        

        if(other.gameObject.CompareTag("SpeedItem"))
        {

            speed += 8;
            booster = true;
            other.gameObject.SetActive(false);
        }

      
    }


}
