using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWaveManager : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint; // ���� ����Ʈ

    [SerializeField]
    private GameObject enemyPrefab; // �� ������

    public Button startWaveButton; // ���� ��ư
    public Text timerText; // UI Text ������Ʈ

    public float spawnInterval = 2.0f; // �� ���� ���� (��)
    public int numberOfEnemies = 5; // ������ �� ��
    public float waveDuration = 60.0f; // �� ���� ���� �ð� (��)

    private bool waveActive = false;
    private float currentTime = 0;

    private void Start()
    {
        startWaveButton.onClick.AddListener(StartEnemyWave);
    }

    private void Update()
    {
        // �ð� ����
        if (waveActive)
        {
            currentTime += Time.deltaTime;
            UpdateTimerText();
        }
    }

    private void StartEnemyWave()
    {
        if (!waveActive)
        {
            currentTime = 0; // Ÿ�̸� �ʱ�ȭ
            UpdateTimerText();

            // 60�� ���� �� ������ �ݺ��մϴ�.
            InvokeRepeating("SpawnEnemy", 0, spawnInterval);
            Invoke("StopEnemyWave", waveDuration);
            waveActive = true;
        }
    }

    private void SpawnEnemy()
    {
        // ���� ����Ʈ���� �� ����
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }

    private void StopEnemyWave()
    {
        // �� ���� ����
        CancelInvoke("SpawnEnemy");
        waveActive = false;
    }

    private void UpdateTimerText()
    {
        // UI Text�� ����Ͽ� �ð��� ǥ��
        float remainingTime = waveDuration - currentTime;
        int seconds = Mathf.FloorToInt(remainingTime);

        // �ð��� 0 ���Ϸ� �������� Ÿ�̸Ӹ� �����ϰ� �ؽ�Ʈ�� ������Ʈ
        if (remainingTime <= 0)
        {
            timerText.text = "";
        }
        else
        {
            timerText.text = string.Format("{0}", seconds);
        }
    }
}
