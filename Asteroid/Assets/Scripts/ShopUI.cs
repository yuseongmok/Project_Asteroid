using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour
{
    public List<Button> buttons; // Button�� ������ List ����
    public Sprite[] images;
    public Image targetImage;
    public int ImageIndex = 0;

    public TextMeshProUGUI TowerName;
    public TextMeshProUGUI TowerPower;
    public TextMeshProUGUI TowerSpeed;
    public TextMeshProUGUI TowerExplanation;
    public Button tower;
    public List<GameObject> Tower;
    public Transform TowerSlot;

    public List<int> towerCosts;

    void Start()
    {
        // ��� Button�� Ŭ�� �̺�Ʈ�� ����
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(() => OnButtonClick(buttons.IndexOf(btn)));
        }
        tower.onClick.AddListener(TowerInstantiate);
    }

    //���� �����ϱ� ��ư ������ �����ϴ� �Լ�
    private void TowerInstantiate()
    { 
        int towerCost = towerCosts[ImageIndex];

        // ���� ���� �������� ���� (MoneyManager�� �ִ� Money ������ Ȱ��)
        int currentMoney = MoneyManager.Instance.Money;

        // ����� ���� �ִ��� Ȯ��
        if (currentMoney >= towerCost)
        {
            // ����� ���� �ִٸ� Ÿ�� ��ġ ����
            Instantiate<GameObject>(Tower[ImageIndex], TowerSlot.position, Quaternion.identity);

            // Ÿ�� ��븸ŭ �� ����
            MoneyManager.Instance.SpendMoney(towerCost);
        }
        else
        {
            Debug.Log("���� �����ؿ�");
        }
        //Instantiate<GameObject>(Tower[ImageIndex], TowerSlot.position, Quaternion.identity);
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

            case 2:
                TowerName.text = "��ȹ���� Ÿ��";
                TowerPower.text = "���ݷ� 10";
                TowerSpeed.text = "����";
                TowerExplanation.text = "���� ��ȹ�� �ȵ� Ÿ���̴�";
                break;

            default:
                
                break;
        }
    }

}
