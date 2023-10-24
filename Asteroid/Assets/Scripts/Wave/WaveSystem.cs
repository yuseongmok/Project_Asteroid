using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    //���� �Ŵ���
    public SoundManager soundManager;

    //Slot UI
    public GameObject UITowerButtonGroup;
    


    private void Start()
    {
        //Wave �ڵ�
        waveButton.onClick.AddListener(StartWave);  // ��ư Ŭ�� �̺�Ʈ ������ �߰�
        UpdateWaveText();  // �ʱ� Wave ��ȣ ǥ��
        soundManager.PlaySound(0);


    }

    private void UpdateWaveText()
    {
        //Wave �ڵ�
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
                
                soundManager.StopSound(1);
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
    }

    // Wave�� �����ϴ� �Լ�
    private void StartWave()
    {
        //Wave
        isWaveInProgress = true;  // Wave ���� ������ ����
        UITowerButtonGroup.SetActive(false);
        waveButton.interactable = false;

        if (currentEnemyIndex < enemyPrefabs.Count)
        {
            // ������� Enemy �������� �����Ͽ� ����
            GameObject enemy = Instantiate(enemyPrefabs[currentEnemyIndex], spawnPoint.position, Quaternion.identity);
            Enemy = enemy;
            currentEnemyIndex++;
            soundManager.StopSound(0);
            soundManager.PlaySound(1);
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

    void Shoot()
    {
        if(timer >= 1.5f)
        {
            // �Ѿ��� �߻� ��ġ���� ����
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            timer = 0.0f;
        }
    }
}


