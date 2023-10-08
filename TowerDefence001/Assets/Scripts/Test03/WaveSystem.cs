using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSystem : MonoBehaviour
{
    public Button waveButton;  // Wave를 시작할 버튼
    public TextMeshProUGUI waveText;      // Wave 수를 표시할 UI Text 요소
    public List<GameObject> enemyPrefabs;  // Enemy 게임 오브젝트 프리팹 리스트
    public Transform spawnPoint;  // Enemy가 생성될 위치

    private int currentWave = 0;  // 현재 Wave 번호
    private int currentEnemyIndex = 0;  // 현재 Enemy 프리팹 인덱스
    private bool isWaveInProgress = false;  // Wave 진행 중인지 여부

    private void Start()
    {
        waveButton.onClick.AddListener(StartWave);  // 버튼 클릭 이벤트 리스너 추가
        UpdateWaveText();  // 초기 Wave 번호 표시
    }

    private void UpdateWaveText()
    {
        if (currentEnemyIndex < enemyPrefabs.Count)
        {
            waveText.text = "Wave " + currentWave.ToString();  // UI Text 업데이트
        }
        else
        {
            waveText.text = "업데이트 중";  // 다음 GameObject가 없을 때 "업데이트 중"으로 표시
        }
    }

    private void Update()
    {
        if (isWaveInProgress)
        {
            // Wave 진행 중에는 버튼을 비활성화
            waveButton.interactable = false;

            // Wave 진행 중인지 체크하고, 모든 Enemy가 없어지면 Wave 종료
            if (CheckWaveComplete())
            {
                isWaveInProgress = false;
                waveButton.interactable = true;  // Wave가 종료되면 버튼을 활성화
            }
        }
        else
        {
            // Wave가 종료되면 버튼을 활성화
            waveButton.interactable = true;
        }
    }

    // Wave를 시작하는 함수
    private void StartWave()
    {
        currentWave++;  // Wave 번호 증가
        UpdateWaveText();  // Wave 번호 업데이트

        if (currentEnemyIndex < enemyPrefabs.Count)
        {
            // 순서대로 Enemy 프리팹을 선택하여 생성
            GameObject enemy = Instantiate(enemyPrefabs[currentEnemyIndex], spawnPoint.position, Quaternion.identity);
            currentEnemyIndex++;
        }
        else
        {
            Debug.Log("모든 Enemy 프리팹이 생성되었습니다.");
        }

        isWaveInProgress = true;  // Wave 진행 중으로 설정
    }

    // Wave가 완료되었는지 확인하는 함수
    private bool CheckWaveComplete()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return enemies.Length == 0;
    }
}

