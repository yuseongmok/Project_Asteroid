using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float lifespan = 2.0f;
    public float moveSpeed = 5.0f; // ���� �̵� �ӵ�
    public int damage = 10; // �Ѿ� ������
    public float currentTime = 0;
    void Update()
    {
        // ���� �ð��� ������ŵ�ϴ�.
        currentTime += Time.deltaTime;

        // ������ ���� �Ѿ��� ó���մϴ�.
        if (currentTime >= lifespan)
        {
            Destroy(gameObject); // �Ѿ��� �ı��մϴ�.
        }

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
