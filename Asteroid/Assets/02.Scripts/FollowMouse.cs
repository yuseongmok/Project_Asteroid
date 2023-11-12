using UnityEngine;
using UnityEngine.UI;

public class FollowMouse : MonoBehaviour
{
    public Texture2D cursorTexture; // Inspector���� �Ҵ��� Ŀ�� �̹���
    public Vector2 hotSpot = Vector2.zero; // Ŀ�� �̹����� �߽� ��ġ

    void Start()
    {
        // CursorMode.ForceSoftware�� ����Ͽ� �ϵ���� ������ ������� �ʵ��� ����
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.ForceSoftware);
    }

    void Update()
    {
        // ���콺 ��ġ�� ��������
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane; // ī�޶���� �Ÿ��� ����

        // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // �̹����� ���콺 ��ġ�� �̵�
        transform.position = worldMousePosition;
    }
}
