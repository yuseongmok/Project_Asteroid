using UnityEngine;

public class Pingu : MonoBehaviour
{
    public float moveSpeed = 5f;  // �̵� �ӵ� ������ ���� ����
    public float maxY = 5f;       // �̵� ������ �ִ� Y ��ǥ
    public float minY = -5f;      // �̵� ������ �ּ� Y ��ǥ

    private int direction = 1;    // �̵� ������ ��Ÿ���� ���� (1: ��, -1: �Ʒ�)

    void Update()
    {
        // ��ü�� ���� �̵� ����� �ӵ��� ���� �̵���ŵ�ϴ�.
        transform.Translate(Vector3.up * direction * moveSpeed * Time.deltaTime);

        // ��ü�� ���� ������ ����� ������ ������ŵ�ϴ�.
        if (transform.position.y >= maxY || transform.position.y <= minY)
        {
            ChangeDirection();
        }
    }

    // �̵� ������ ������Ű�� �Լ�
    void ChangeDirection()
    {
        direction *= -1;
    }
}
