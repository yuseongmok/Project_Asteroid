using UnityEngine;

public class Main_st : MonoBehaviour
{
    public float speed = 2.0f; // ��ü�� ������ �ӵ�
    public float distance = 2.0f; // ������ �Ÿ� (���Ʒ���)

    private Vector3 startPosition;
    private bool movingUp = true;

    void Start()
    {
        // ���� ��ġ ����
        startPosition = transform.position;
    }

    void Update()
    {
        // ��ü�� ���Ʒ��� ������
        if (movingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        // ���� �Ÿ��� �̵��ϸ� ������ �ݴ�� �ٲ�
        if (Vector3.Distance(startPosition, transform.position) >= distance)
        {
            movingUp = !movingUp;
        }
    }
}
