using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // �ִ� ü��
    public int currentHealth; // ���� ü��

    public Slider healthBar; // HP �� UI
    MonsterController Enemy;
    
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            
            Debug.Log("���ݿ� ����");
        }
    }

    


    public void TakeDamage1(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

        if (currentHealth == 0)
        {
           
            Die();
        }
    }

    private void Die()
    {
        
    }
}
