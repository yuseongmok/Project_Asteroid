using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // ���� �̵� �ӵ�
    public int maxHealth = 50; // �ִ� ü��
    private int currentHealth; // ���� ü��

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
        Debug.Log("���ݿ� ����");
        if (currentHealth <= 0)
        {
            Die(); // ü���� 0 ���Ϸ� �������� ��� ó��
        }
    }

    void Die()
    {
        // ���⿡ �� ĳ���Ͱ� ����� �� ������ �۾��� �߰��� �� �ֽ��ϴ�.
        // ��: ���� ����, ����Ʈ ��� ��
        gameObject.SetActive(false);
    }

    internal void ResetHealth()
    {
        throw new NotImplementedException();
    }
}
