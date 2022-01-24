using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//���� �÷��̾ �ٰ����� ���� �Ⱥ��̰�(�������ϰ�) �����.
//�� �߰��� �繰 ��ġ�ϱ�, �÷��̾��� ���ӵ��� ���� ���̰�.

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public int speed;
    public int jump;
    private int score = 0;
    public int Max_Score = 6;
    public TextMeshProUGUI countScore; //TextMeshPro ���۷���
    public GameObject WinTextObject;
    public GameObject LoseTextObject;

    private AudioSource audioPoint;
    private AudioSource audioWin;
    private AudioSource audioLose;
    public AudioClip pointsound;
    public AudioClip Winsound;
    public AudioClip Losesound;


    bool fly = false;   //�÷��̾ ���� �������ִ����� Ȯ���ϴ� �����̴�.
    float fly_time = 2f;   //�ٽ� �����ϱ� ���� �ð�
    float flytimer = 0f;    //���� Ÿ�̸�

    bool booster = false;  //�÷��̾ ���� ���ǵ� �������� ���� �������� üũ 
    float speedtime = 3f;  //3�� ���� �÷��̾ ������ ������ش�.
    float speedtimer = 0f; //���ǵ�Ÿ�̸�
    bool startgame = false; //���� ������ �ߴ��� ���ߴ���



    Rigidbody rb;       //������ٵ�
    float horizontal;   //������ ��
    float vertical;    //�����ప
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



        WinTextObject.SetActive(false); //������ �̰�ٴ� �ؽ�Ʈ�� ���۽ÿ� ��Ȱ��ȭ ��Ų��.
        LoseTextObject.SetActive(false);


        Time.timeScale = 0; //ó���� �Ͻ����� �����̴�.
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
        countScore.text = score.ToString() + " / " + Max_Score.ToString(); //���� ��� ������ �Ծ������� �����ش�.

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
        if (fly == true)  //���� ���°� ���̸� 
        {
            flytimer += Time.deltaTime;  //Time.deltaTime�� ���Ѵٴ°� 1�� ���Ѵٴ°Ŷ� �Ȱ���. 
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
            fly = true;                   //���� ���� TRUE
        }
        
         if(Time.timeScale == 0 )
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                startgame = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                //GetActiveScene().name�� ���� ���� ���� �̸��� �޾ƿ´�.
                //LoadScene�� ���� �ش� scene�� �����Ѵ�.
            }
        }
    }

    private void OnCollisionEnter(Collision collision) //�ݶ����� �Լ�
    {

       if(collision.gameObject.CompareTag("Enemy"))
        {
            LoseTextObject.SetActive(true);
            audioLose.Play();
            Time.timeScale = 0; //timeScale�� �⺻���� 1�̴�.  

               


        }
    }

    
private void OnTriggerEnter(Collider other) //Ʈ���� �Լ� 
    {
        if(other.gameObject.CompareTag("Point"))
        {
            score++;
            audioPoint.Play();

            if (score == Max_Score)  //score�� max score�� �Ǹ� �̰�ٴ� ������ �Բ� Win text�� Ȱ��ȭ��Ų��. ���� �Ͻ�����
            {

                audioWin.Play();
                WinTextObject.SetActive(true);
                Time.timeScale = 0; //timeScale�� �⺻���� 1�̴�.  


            }

            other.gameObject.SetActive(false);  //���� point ���� ���ֱ�
        }
        

        if(other.gameObject.CompareTag("SpeedItem"))
        {

            speed += 8;
            booster = true;
            other.gameObject.SetActive(false);
        }

      
    }


}
