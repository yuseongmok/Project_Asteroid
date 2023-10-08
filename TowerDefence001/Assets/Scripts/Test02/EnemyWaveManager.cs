using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWaveManager : MonoBehaviour
{
          //웨이브 수 리스트 코드 작성 해야함
    public List<GameObject> EnemyCount;                             //적 순서
    public List<GameObject> startPos;            //적 스폰 위치
    public float Spawntime = 0.0f;
    public float currentTime = 0;
    public int SpawnCount = 0;
    public Button waveButton;
    private bool waveStart = false;
    

    void Start()
    {
        waveButton.onClick.AddListener(MakeWave);

    }

   
    void Update()
    {
        if(waveStart == true)
        {
            if (EnemyCount.Count <= SpawnCount) return;
            currentTime += Time.deltaTime;
            if (currentTime > Spawntime)
            {
                currentTime = 0;
                MakeWave();
            }
        }
        
    }

    public void MakeWave()
    {
        waveStart = true;
        GameObject go = Instantiate(EnemyCount[SpawnCount]);
        
        SpawnCount++;
    }
}
