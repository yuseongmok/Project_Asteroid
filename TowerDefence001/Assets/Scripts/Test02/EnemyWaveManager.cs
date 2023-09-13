using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWaveManager : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint; // 스폰 포인트

    [SerializeField]
    private GameObject enemyPrefab; // 적 프리팹

    public Button startWaveButton; // 시작 버튼
    public Text timerText; // UI Text 컴포넌트

    public float spawnInterval = 2.0f; // 적 스폰 간격 (초)
    public int numberOfEnemies = 5; // 생성될 적 수
    public float waveDuration = 60.0f; // 적 생성 지속 시간 (초)

    private bool waveActive = false;
    private float currentTime = 0;

    private void Start()
    {
        startWaveButton.onClick.AddListener(StartEnemyWave);
    }

    private void Update()
    {
        // 시간 갱신
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
            currentTime = 0; // 타이머 초기화
            UpdateTimerText();

            // 60초 동안 적 생성을 반복합니다.
            InvokeRepeating("SpawnEnemy", 0, spawnInterval);
            Invoke("StopEnemyWave", waveDuration);
            waveActive = true;
        }
    }

    private void SpawnEnemy()
    {
        // 스폰 포인트에서 적 생성
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }

    private void StopEnemyWave()
    {
        // 적 생성 중지
        CancelInvoke("SpawnEnemy");
        waveActive = false;
    }

    private void UpdateTimerText()
    {
        // UI Text를 사용하여 시간을 표시
        float remainingTime = waveDuration - currentTime;
        int seconds = Mathf.FloorToInt(remainingTime);

        // 시간이 0 이하로 떨어지면 타이머를 중지하고 텍스트를 업데이트
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
