using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rr : MonoBehaviour
{

    public float rotationSpeed = 30.0f; // ȸ�� �ӵ� (�ʴ� ȸ�� ����)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ��ü�� ȸ����ŵ�ϴ�.
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
