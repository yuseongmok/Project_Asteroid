using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform player; // ī�޶� ����ٴ� ��� �÷��̾�

    void Update()
    {
        if (player != null)
        {
            // �÷��̾��� ���� ��ġ�� �޾ƿ� ī�޶��� ��ġ�� ������Ʈ
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = targetPosition;
        }
    }
}
