using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform target; // Enemy Ÿ��
    public Transform gunTransform; // �Ѿ� �߻� ��ġ
    public GameObject bulletPrefab; // �Ѿ� ������
    public float range = 10f; // ���� �Ÿ�
    public float fireRate = 1f; // �߻� �ӵ�
    private float fireCountdown = 0f;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // �ֱ������� Ÿ�� ������Ʈ
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
        TowerBullet bullet = bulletGO.GetComponent<TowerBullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    // ���⿡ ���� ���� �� Ư���� �����մϴ�.

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Tower turret = other.GetComponent<Tower>();
            if (turret != null)
            {
                turret.target = transform;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Tower turret = other.GetComponent<Tower>();
            if (turret != null && turret.target == transform)
            {
                turret.target = null;
            }
        }

    }
}