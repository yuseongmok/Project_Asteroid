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
    public GameObject Panal;
    MonsterController Enemy;
    
    // ������ ǥ�� �ð�
    private float damageDisplayTime = 0.2f;

    private void Start()
    {
        Panal.SetActive(false);
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
        StartCoroutine(DisplayDamagePanal()); // ������ �г��� ǥ���ϴ� �ڷ�ƾ ����

        healthBar.value = currentHealth;

        if (currentHealth == 0)
        {
            SceneManager.LoadScene("Stage");
        }
    }

    // ������ �г��� ǥ���ϴ� �ڷ�ƾ
    private IEnumerator DisplayDamagePanal()
    {
        Panal.SetActive(true);
        yield return new WaitForSeconds(damageDisplayTime);
        Panal.SetActive(false);
    }
}
