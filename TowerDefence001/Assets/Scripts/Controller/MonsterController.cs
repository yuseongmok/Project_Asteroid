using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // ���� �̵� �ӵ�
    public int maxHealth = 50; // �ִ� ü��
    private int currentHealth; // ���� ü��
    public int damage = 10;

    void Start()
    {
        currentHealth = maxHealth; // ������ �� ���� ü���� �ִ� ü������ ����
    }
    void Update()
    {
        // ���͸� ���������� �̵�
        Vector2 moveDirection = new Vector2(-1, 0); // ���������� �̵��ϴ� �������� ����
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    // �� ĳ���Ϳ��� �������� ������ �Լ�
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // ��������ŭ ���� ü�� ����
        Debug.Log("���� ������ ����");
        if (currentHealth <= 0)
        {
            Die(); // ü���� 0 ���Ϸ� �������� ��� ó��
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void Die()
    {
        if (gameObject.CompareTag("Money"))
        {
            MoneyManager.Instance.AddMoney(25);
            Debug.Log("�� � �ı���");
        }
            // ���⿡ �� ĳ���Ͱ� ����� �� ������ �۾��� �߰��� �� �ֽ��ϴ�.
            // ��: ���� ����, ����Ʈ ��� ��
            gameObject.SetActive(false);
    }

    internal void ResetHealth()
    {
        throw new NotImplementedException();
    }
}
