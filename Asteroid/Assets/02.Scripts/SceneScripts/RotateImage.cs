using UnityEngine;

public class RotateImage : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // ȸ�� �ӵ� (�ʴ� ����)

    void Update()
    {
        // �̹����� ȸ����ŵ�ϴ�.
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
