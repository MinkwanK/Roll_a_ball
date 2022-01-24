using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        //프레임이 아닌 초를 기준으로 회전
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
