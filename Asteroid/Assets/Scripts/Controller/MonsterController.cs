using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // ���� �̵� �ӵ�
    public int maxHealth = 50; // �ִ� ü��
    private int currentHealth; // ���� ü��
    public int damage;
    public PlayerHealth player;
    void Start()
    {
        currentHealth = maxHealth; // ������ �� ���� ü���� �ִ� ü������ ����
        player = GameObject.Find("PlayerBody").GetComponent<PlayerHealth>();
    }
    void Update()
    {
        // ���͸� ���������� �̵�
        Vector2 moveDirection = new Vector2(-1, 0); // ���������� �̵��ϴ� �������� ����
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    // �� ĳ���Ϳ��� �������� ������ �Լ�
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ��������ŭ ���� ü�� ����
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
            player.TakeDamage1(damage);
            //TakeDamage(player.TakeDamage(damage));
            Destroy(gameObject);
        }
    }

    void Die()
    {
        if (gameObject.CompareTag("Money"))
        {
            MoneyManager.Instance.AddMoney(1000);
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
