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
    public SoundManager soundManager;

    // Slow Bullet ����
    private float slow;
    private float timer = 0;
    private float currentTime = 1f;
    private bool SlowTF = false;

    void Start()
    {
        currentHealth = maxHealth; // ������ �� ���� ü���� �ִ� ü������ ����
        player = GameObject.Find("PlayerBody").GetComponent<PlayerHealth>();
        slow = moveSpeed;
    }
    void Update()
    {
        // ���͸� ���������� �̵�
        Vector2 moveDirection = new Vector2(-1, 0); // ���������� �̵��ϴ� �������� ����
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        if(SlowTF == true)  // Slow ���� �ð�
        {
            timer += Time.deltaTime;

            if (timer >= currentTime)
            {
                SlowTime();
                SlowTF = false;
                timer = 0;
            }
        }
    }

    // �� ĳ���Ϳ��� �������� ������ �Լ�
    public void TakeDamage(int damage)
    {
        soundManager.PlaySound(0);
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

        if(other.CompareTag("Bullet_Slow"))
        {
            moveSpeed = slow * 0.5f;    // �̵��ӵ� 50% ������
            SlowTF = true;
        }
    }

    private void SlowTime()     // ���� �̵��ӵ��� �ǵ��ƿ�
    {
        moveSpeed = slow;
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
