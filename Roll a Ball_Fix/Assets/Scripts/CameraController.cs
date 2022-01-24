using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;


    private Vector3 offset; //스크립트 내에서 값을 설정하기에 private
    void Start()
    {
        offset = transform.position - player.transform.position;
        //카메라 오브젝트의 위치 - 플레이어 오브젝트의 위치
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        //위치만 따라가고 회전은 따라가지않음
        //플레이어가 움직임을 완료할때까지는 카메라 위치 설정하지않음
    }
}
