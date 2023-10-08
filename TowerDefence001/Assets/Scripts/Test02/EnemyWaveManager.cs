using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWaveManager : MonoBehaviour
{
          //���̺� �� ����Ʈ �ڵ� �ۼ� �ؾ���
    public List<GameObject> EnemyCount;                             //�� ����
    public List<GameObject> startPos;            //�� ���� ��ġ
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
