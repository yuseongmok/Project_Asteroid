using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower2 : MonoBehaviour
{
    public Transform target; // Enemy Ÿ��
    public Transform gunTransform; // �Ѿ� �߻� ��ġ
    public GameObject bulletPrefab; // �Ѿ� ������
    public float range = 10f; // ���� �Ÿ�
    public float fireRate = 1f; // �߻� �ӵ�
    private float fireCountdown = 0f;
    public SoundManager soundManager;

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
        // Ÿ�� ���� ���͸� ���ɴϴ�.
        Vector3 targetDirection = (target.position - gunTransform.position).normalized;

        // Z�� ȸ�� ������ ����մϴ�.
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        // �Ѿ� �߻� ��ġ�� Z�� ȸ���� �����մϴ�.
        gunTransform.rotation = Quaternion.Euler(0f, 0f, angle);

        // �� ���� �Ѿ� �� ������ ���� �������� ����մϴ�.
        float verticalOffset = 0.5f; // ���� �������� �����Ͽ� �� �Ѿ� �� ������ ������ �����մϴ�.

        // �� ���� �Ѿ� �࿡ ���� ��ġ�� ����մϴ�.
        Vector3 position1 = gunTransform.position + gunTransform.up * verticalOffset;
        Vector3 position2 = gunTransform.position - gunTransform.up * verticalOffset;

        // �� �Ѿ� �࿡ ���� Z-�� ȸ���� �����մϴ�.
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

        GameObject bulletGO1 = Instantiate(bulletPrefab, position1, rotation);
        GameObject bulletGO2 = Instantiate(bulletPrefab, position2, rotation);

        TowerBullet bullet1 = bulletGO1.GetComponent<TowerBullet>();
        TowerBullet bullet2 = bulletGO2.GetComponent<TowerBullet>();
        soundManager.PlaySound(0);
        if (bullet1 != null)
        {
            bullet1.Seek(target);
        }

        if (bullet2 != null)
        {
            bullet2.Seek(target);
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
