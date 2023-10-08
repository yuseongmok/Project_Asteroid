using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSystem : MonoBehaviour
{
    //Wave
    public Button waveButton;  // Wave�� ������ ��ư
    public TextMeshProUGUI waveText;      // Wave ���� ǥ���� UI Text ���
    public List<GameObject> enemyPrefabs;  // Enemy ���� ������Ʈ ������ ����Ʈ
    public Transform spawnPoint;  // Enemy�� ������ ��ġ

    private int currentWave = 0;  // ���� Wave ��ȣ
    private int currentEnemyIndex = 0;  // ���� Enemy ������ �ε���
    private bool isWaveInProgress = false;  // Wave ���� ������ ����

    //Player
    public Transform pivot;               // �Ǻ� ����Ʈ
    public GameObject bulletPrefab;       // �Ѿ� ������
    public Transform firePoint;           // �Ѿ� �߻� ��ġ
    public float rotationSpeed = 5.0f;    // �Ǻ� ȸ�� �ӵ�
    public float minAngle = -45.0f;       // �ּ� ȸ�� ����
    public float maxAngle = 45.0f;        // �ִ� ȸ�� ����
    private bool isFiring = false;        // �߻� �� ����


   

    private void Start()
    {
        //Wave
        waveButton.onClick.AddListener(StartWave);  // ��ư Ŭ�� �̺�Ʈ ������ �߰�
        UpdateWaveText();  // �ʱ� Wave ��ȣ ǥ��

        
    }

    private void UpdateWaveText()
    {
        //Wave
        if (currentEnemyIndex < enemyPrefabs.Count)
        {
            waveText.text = "Wave " + currentWave.ToString();  // UI Text ������Ʈ
        }
        else
        {
            waveText.text = "������Ʈ ��";  // ���� GameObject�� ���� �� "������Ʈ ��"���� ǥ��
        }
    }

    private void Update()
    {
        
        if (isWaveInProgress)
        {
            //Wave

            // Wave ���� �߿��� ��ư�� ��Ȱ��ȭ
            waveButton.interactable = false;

            // Wave ���� ������ üũ�ϰ�, ��� Enemy�� �������� Wave ����
            if (CheckWaveComplete())
            {
                isWaveInProgress = false;
                waveButton.interactable = true;  // Wave�� ����Ǹ� ��ư�� Ȱ��ȭ
            }

            //Player

            // �Ǻ��� ���콺 ��ġ�� ȸ����Ŵ
            RotatePivotToMouse();

            // ���콺 Ŭ������ �Ѿ� �߻�
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }

            
        }
        else
        {
            // Wave�� ����Ǹ� ��ư�� Ȱ��ȭ
            waveButton.interactable = true;
        }

        
    }

    // Wave�� �����ϴ� �Լ�
    private void StartWave()
    {
        //Wave
        currentWave++;  // Wave ��ȣ ����
        UpdateWaveText();  // Wave ��ȣ ������Ʈ

        if (currentEnemyIndex < enemyPrefabs.Count)
        {
            // ������� Enemy �������� �����Ͽ� ����
            GameObject enemy = Instantiate(enemyPrefabs[currentEnemyIndex], spawnPoint.position, Quaternion.identity);
            currentEnemyIndex++;
        }
        else
        {
            Debug.Log("��� Enemy �������� �����Ǿ����ϴ�.");
        }

        isWaveInProgress = true;  // Wave ���� ������ ����
    }

    // Wave�� �Ϸ�Ǿ����� Ȯ���ϴ� �Լ�
    private bool CheckWaveComplete()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return enemies.Length == 0;
    }

    //Player
    void RotatePivotToMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 direction = (mousePosition - pivot.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ȸ�� ������ ����
        angle = Mathf.Clamp(angle, minAngle, maxAngle);

        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        pivot.rotation = Quaternion.Slerp(pivot.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        // �Ѿ��� �߻� ��ġ���� ����
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
