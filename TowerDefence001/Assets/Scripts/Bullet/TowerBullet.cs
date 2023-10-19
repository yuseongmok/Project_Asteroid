using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    private Transform target;
    public float speed = 10f;
    public int damage = 10;
    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        // ���⿡�� ��(Enemy)�� �����ϰų� �ı��ϴ� �ڵ带 �߰��մϴ�.
        // ��: target.GetComponent<Enemy>().TakeDamage(damage);
        Destroy(gameObject);

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

        if (other.CompareTag("Money"))
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
