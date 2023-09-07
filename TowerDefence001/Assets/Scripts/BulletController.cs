using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // ���� �̵� �ӵ�
    public int damage = 10; // �Ѿ� ������

    void Update()
    {
        // ���͸� ���������� �̵�
        Vector2 moveDirection = new Vector2(1, 0); // ���������� �̵��ϴ� �������� ����
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �Ѿ��� �ٸ� ������Ʈ�� �浹���� ��
        if (other.CompareTag("Enemy"))
        {
            // �� ������Ʈ�� �������� ����
            MonsterController enemyHealth = other.GetComponent<MonsterController>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            // �Ѿ� ����
            Destroy(gameObject);
        }
    }
}
