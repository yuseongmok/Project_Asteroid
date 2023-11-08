using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance { get; private set; }
    public int Money { get; private set; }

    [SerializeField]
    private TextMeshProUGUI moneyText; // Money ��ġ�� ǥ���� UI Text

    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    

    private void UpdateMoneyText()
    {
        moneyText.text = "" + Money.ToString(); // Money ��ġ�� UI Text�� ǥ��
    }

    public void AddMoney(int amount)
    {
        Money += amount;
        UpdateMoneyText();
    }

    public void SpendMoney(int amount)
    {
        if (Money >= amount)
        {
            Money -= amount;
            UpdateMoneyText();
        }
        else
        {
            Debug.Log("Not enough money!");
        }
    }

    private void Start()
    {
        UpdateMoneyText(); // ���� ���� �� Money ��ġ�� UI Text�� ǥ��
    }
}
