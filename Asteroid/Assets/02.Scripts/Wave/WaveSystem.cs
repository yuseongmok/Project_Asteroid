using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WaveSystem : MonoBehaviour
{
    //Wave(wave ����)
    public Button waveButton;              // Wave�� ������ ��ư
    public TextMeshProUGUI waveText;       // Wave ���� ǥ���� UI Text ���
    public List<GameObject> enemyPrefabs;  // �� ���̺긶�� ������ Enemy ����
    public Transform spawnPoint;           // Enemy�� ������ ��ġ
    public Image imageToControl;        // ����ų� ǥ���� �̹���

    private int currentWave = 0;            // ���� Wave ��ȣ
    private int currentEnemyIndex = 0;      // ���� Enemy ������ �ε���
    private bool isWaveInProgress = false;  // Wave ���� ������ ����
    public GameObject Enemy;

    //Player(���� ����)
    public Transform pivot;               // �Ǻ� ����Ʈ
    public GameObject bulletPrefab;       // �Ѿ� ������
    public Transform firePoint;           // �Ѿ� �߻� ��ġ
    public float rotationSpeed = 5.0f;    // �Ǻ� ȸ�� �ӵ�
    public float minAngle = -45.0f;       // �ּ� ȸ�� ����
    public float maxAngle = 45.0f;        // �ִ� ȸ�� ����
    public float timer = 0.0f;
    private bool TowerOnOff = true;
    public Button ToswerOn;

    //���� �Ŵ���
    public SoundManager soundManager;

    //Slot UI
    public GameObject UITowerButtonGroup;
    public GameObject ShopUI;

    private void Start()
    {
        //Wave �ڵ�
        waveButton.onClick.AddListener(StartWave);  // ��ư Ŭ�� �̺�Ʈ ������ �߰�
        ToswerOn.onClick.AddListener(TowerOn);
        UpdateWaveText();  // �ʱ� Wave ��ȣ ǥ��
        soundManager.PlaySound(0);
        MoneyManager.Instance.AddMoney(50);

    }
    // Wave Text 
    private void UpdateWaveText()
    {
        //Wave �ڵ�
        if (currentEnemyIndex < enemyPrefabs.Count + 1)
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
        // Wave ����� ��
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
                UITowerButtonGroup.SetActive(true);
                
                
                Destroy(Enemy);
            }

            //Player(�������� �ڵ�)

            // �Ǻ��� ���콺 ��ġ�� ȸ����Ŵ
            RotatePivotToMouse();

            timer += Time.deltaTime;

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

        // EscŰ ������ Player ���� Ȱ��ȭ,��Ȱ��ȭ
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(TowerOnOff)
            {
                TowerOnOff = false;
            }
            else
            {
                TowerOnOff = true;
            }
        }
    }

    public void TowerOn()
    {
        TowerOnOff = true;
    }

    // Wave�� �����ϴ� �Լ�
    private void StartWave()
    {
        //Wave
        isWaveInProgress = true;  // Wave ���� ������ ����
        UITowerButtonGroup.SetActive(false);
        waveButton.interactable = false;
        ShopUI.SetActive(false); //ShopUi â ��Ȱ��ȭ
        soundManager.PlaySound(3);
        soundManager.PlaySound(1);

        if (currentEnemyIndex < enemyPrefabs.Count)
        {
            // ������� Enemy �������� �����Ͽ� ����
            GameObject enemy = Instantiate(enemyPrefabs[currentEnemyIndex], spawnPoint.position, Quaternion.identity);
            Enemy = enemy;
            currentEnemyIndex++;
            soundManager.StopSound(0);
            if(currentEnemyIndex == 5)
            {
                EndScene();
            }
        }
        else
        {
            Debug.Log("��� Enemy �������� �����Ǿ����ϴ�.");
        }
        currentWave++;  // Wave ��ȣ ����
        UpdateWaveText();  // Wave ��ȣ ������Ʈ
        HideImage();
    }

    // Wave�� �Ϸ�Ǿ����� Ȯ���ϴ� �Լ�
    private bool CheckWaveComplete()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return enemies.Length == 0;
        

    }

    //���̺� ��ư �̹����� ����
    private void HideImage()
    {
        if (imageToControl != null)
        {
            imageToControl.enabled = false;
        }
    }

    //���̺� ��ư �̹��� �ٽ� ���̱�
    private void ShowImage()
    {
        if (imageToControl != null)
        {
            imageToControl.enabled = true;
        }
    }

    //Player(�������� �ڵ�)
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

    // Player ���� �Լ�
    void Shoot()
    {
        if(TowerOnOff == true)
        {
            if (timer >= 0.33f)
            {
                soundManager.PlaySound(4);
                // �Ѿ��� �߻� ��ġ���� ����
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                timer = 0.0f;
            }
        }
       
    }

    public void EndScene()
    {
        SceneManager.LoadScene("Story02");
    }
}

