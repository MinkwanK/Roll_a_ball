using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        //�������� �ƴ� �ʸ� �������� ȸ��
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
