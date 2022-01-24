using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
   Vector3 target;
    public float speed = 10f;
    //public Transform target;

    //NevMesh는 NavAgent가 경로를 그리기 위한 바탕이다. (필수)
    NavMeshAgent nav;  //사용하기 위해서는 UnityEngine.AI import
    // Start is called before the first frame update
    //void Awake()
    //{
   //     nav = GetComponent<NavMeshAgent>();
   // }

    

    // Update is called once per frame
    void Update()
    {

       // nav.SetDestination(target.position); //도착할 목표 위치 지정 함수

       target = GameObject.Find("Player").transform.position;
       transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
    }
}
