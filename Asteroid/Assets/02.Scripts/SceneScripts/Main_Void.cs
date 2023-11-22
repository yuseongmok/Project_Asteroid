using UnityEngine;

public class Main_Void : MonoBehaviour
{
    public float tiltAngle = 30.0f; // ���� ���� ����
    public float tiltSpeed = 2.0f; // ���� �ӵ� ����
    private float currentTilt = 0.0f; // ���� ����

    void Update()
    {
        // �̹����� �ε巴�� �Դٰ����ϵ��� ����� �κ�
        float targetTilt = Mathf.Sin(Time.time * tiltSpeed) * tiltAngle;
        currentTilt = Mathf.LerpAngle(currentTilt, targetTilt, Time.deltaTime);

        transform.rotation = Quaternion.Euler(0, 0, currentTilt);
    }
}