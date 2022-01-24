using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
   Vector3 target;
    public float speed = 10f;
    //public Transform target;

    //NevMesh�� NavAgent�� ��θ� �׸��� ���� �����̴�. (�ʼ�)
    NavMeshAgent nav;  //����ϱ� ���ؼ��� UnityEngine.AI import
    // Start is called before the first frame update
    //void Awake()
    //{
   //     nav = GetComponent<NavMeshAgent>();
   // }

    

    // Update is called once per frame
    void Update()
    {

       // nav.SetDestination(target.position); //������ ��ǥ ��ġ ���� �Լ�

       target = GameObject.Find("Player").transform.position;
       transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
    }
}
