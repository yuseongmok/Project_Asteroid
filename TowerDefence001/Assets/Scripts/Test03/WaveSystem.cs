using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSystem : MonoBehaviour
{
    public Button waveButton;  // Wave�� ������ ��ư
    public TextMeshProUGUI waveText;      // Wave ���� ǥ���� UI Text ���
    public List<GameObject> enemyPrefabs;  // Enemy ���� ������Ʈ ������ ����Ʈ
    public Transform spawnPoint;  // Enemy�� ������ ��ġ

    private int currentWave = 0;  // ���� Wave ��ȣ
    private int currentEnemyIndex = 0;  // ���� Enemy ������ �ε���
    private bool isWaveInProgress = false;  // Wave ���� ������ ����

    private void Start()
    {
        waveButton.onClick.AddListener(StartWave);  // ��ư Ŭ�� �̺�Ʈ ������ �߰�
        UpdateWaveText();  // �ʱ� Wave ��ȣ ǥ��
    }

    private void UpdateWaveText()
    {
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
            // Wave ���� �߿��� ��ư�� ��Ȱ��ȭ
            waveButton.interactable = false;

            // Wave ���� ������ üũ�ϰ�, ��� Enemy�� �������� Wave ����
            if (CheckWaveComplete())
            {
                isWaveInProgress = false;
                waveButton.interactable = true;  // Wave�� ����Ǹ� ��ư�� Ȱ��ȭ
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
}

