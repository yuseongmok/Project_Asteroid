using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour
{
    public List<Button> buttons;
    public Sprite[] images;
    public Image targetImage;
    public int ImageIndex = 0;

    public TextMeshProUGUI TowerName;
    public TextMeshProUGUI TowerPower;
    public TextMeshProUGUI TowerSpeed;
    public TextMeshProUGUI TowerExplanation;
    public TextMeshProUGUI RailgunMoney;
    public TextMeshProUGUI ShootgunMoney;
    public Button tower;
    public List<GameObject> Tower;
    public List<Transform> TowerSlots; // Change the variable to a list of Transform
    public List<bool> IsSlotOccupied; // To keep track of whether a tower is installed in each slot
    public List<int> towerCosts;

    void Start()
    {
        // Initialize the IsSlotOccupied list
        IsSlotOccupied = new List<bool>(new bool[TowerSlots.Count]);

        // Attach click events to the buttons
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(() => OnButtonClick(buttons.IndexOf(btn)));
        }
        tower.onClick.AddListener(TowerInstantiate);
    }

    private void TowerInstantiate()
    {
        int towerCost = towerCosts[ImageIndex];

        int currentMoney = MoneyManager.Instance.Money;

        if (currentMoney >= towerCost)
        {
            // Find the first available slot
            int slotIndex = FindEmptySlot();

            if (slotIndex != -1)
            {
                // Instantiate the tower at the selected slot
                Instantiate(Tower[ImageIndex], TowerSlots[slotIndex].position, Quaternion.identity);
                IsSlotOccupied[slotIndex] = true;

                // Deduct the tower cost from the money
                MoneyManager.Instance.SpendMoney(towerCost);
            }
            else
            {
                Debug.Log("Ÿ�� ������ �����");
            }
        }
        else
        {
            Debug.Log("���� �����ؿ�");
        }
    }

    private int FindEmptySlot()
    {
        for (int i = 0; i < IsSlotOccupied.Count; i++)
        {
            if (!IsSlotOccupied[i])
            {
                return i;
            }
        }
        return -1; // No available slot
    }

    private void OnButtonClick(int index)
    {
        ImageIndex = index;
        targetImage.sprite = images[index];

        switch (ImageIndex)
        {
            case 0:
                TowerName.text = "������ Ÿ��";
                TowerPower.text = "���ݷ� 100";
                TowerSpeed.text = "����";
                TowerExplanation.text = "�⺻���� Ÿ���̴�";
                break;

            case 1:
                TowerName.text = "���� Ÿ��";
                TowerPower.text = "���ݷ� 200";
                TowerSpeed.text = "����";
                TowerExplanation.text = "�� �߾� �߻��ϴ� Ÿ���̴�";
                break;

            default:

                break;
        }
    }
}
