using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Transform pivot;               // �Ǻ� ����Ʈ
    public GameObject bulletPrefab;       // �Ѿ� ������
    public Transform firePoint;           // �Ѿ� �߻� ��ġ
    public float rotationSpeed = 5.0f;    // �Ǻ� ȸ�� �ӵ�
    public float minAngle = -45.0f;       // �ּ� ȸ�� ����
    public float maxAngle = 45.0f;        // �ִ� ȸ�� ����
    private bool isFiring = false;        // �߻� �� ����

    void Update()
    {
        // �Ǻ��� ���콺 ��ġ�� ȸ����Ŵ
        RotatePivotToMouse();

        // ���콺 Ŭ������ �Ѿ� �߻�
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void RotatePivotToMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 direction = (mousePosition - pivot.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ȸ�� ������ ����
        angle = Mathf.Clamp(angle, minAngle, maxAngle);

        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        pivot.rotation = Quaternion.Slerp(pivot.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        // �Ѿ��� �߻� ��ġ���� ����
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
