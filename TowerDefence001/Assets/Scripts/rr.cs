using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rr : MonoBehaviour
{

    public float rotationSpeed = 30.0f; // 회전 속도 (초당 회전 각도)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 객체를 회전시킵니다.
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
