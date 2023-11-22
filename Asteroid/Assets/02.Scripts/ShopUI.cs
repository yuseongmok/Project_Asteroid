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
    
    
    public TextMeshProUGUI NoMoney;
    public Button tower;
    public List<GameObject> Tower;
    public List<Transform> TowerSlots; // Change the variable to a list of Transform
    public List<bool> IsSlotOccupied; // To keep track of whether a tower is installed in each slot
    public List<int> towerCosts;

    public Button ShopUIX;
    public GameObject ShopUI_1;
    //���� �Ŵ���
    public SoundManager soundManager;
    void Start()
    {
        NoMoney.enabled = false;
        // Initialize the IsSlotOccupied list
        IsSlotOccupied = new List<bool>(new bool[TowerSlots.Count]);

        // Attach click events to the buttons
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(() => OnButtonClick(buttons.IndexOf(btn)));
        }
        tower.onClick.AddListener(TowerInstantiate);
        ShopUIX.onClick.AddListener(UIX);
    }

    

    private void TowerInstantiate()
    {
        soundManager.PlaySound(0);
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
                soundManager.PlaySound(1);
            }
            else
            {
                Debug.Log("Ÿ�� ������ �����");
            }
        }
        else
        {
            StartCoroutine(ShowNoMoneyText());
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
        soundManager.PlaySound(0);
        ImageIndex = index;
        targetImage.sprite = images[index];

        switch (ImageIndex)
        {
            case 0:
                TowerName.text = "���ϰ�";
                TowerPower.text = "���ݷ� 100";
                TowerSpeed.text = "����";
                TowerExplanation.text = "���ݷ��� ���� �������� �߻�";
                break;

            case 1:
                TowerName.text = "����跲";
                TowerPower.text = "���ݷ� 200";
                TowerSpeed.text = "����";
                TowerExplanation.text = "�ι��� �߻�ü�� �߻�";
                break;

            default:

                break;
        }
    }

    private IEnumerator ShowNoMoneyText()
    {
        NoMoney.enabled = true;
        yield return new WaitForSeconds(0.8f); // �ʿ信 ���� ���� �ð��� ������ �� �ֽ��ϴ�.
        NoMoney.enabled = false;
    }

    public void UIX()
    {
        ShopUI_1.SetActive(false);
        soundManager.PlaySound(0);
    }
}
