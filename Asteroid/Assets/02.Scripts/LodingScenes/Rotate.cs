using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 20f; // ȸ�� �ӵ� (�ʴ� 20��)
    public float moveSpeed = 1f; // �̵� �ӵ�
    public float amplitude = 1f; // ���Ʒ��� �����̴� ����

    private Vector3 initialPosition;
    private float time;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // ��ü�� �������� �̵�
        Vector3 moveDirection = Vector3.left;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // ��ü�� ȸ��
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // ��ü�� ���Ʒ��� ������
        time += Time.deltaTime;
        float yOffset = Mathf.Sin(time) * amplitude;
        transform.position = new Vector3(transform.position.x, initialPosition.y + yOffset, transform.position.z);
    }
}
