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

    void Start()
    {
        // ��� Button�� Ŭ�� �̺�Ʈ�� ����
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(() => OnButtonClick(buttons.IndexOf(btn)));
        }
        tower.onClick.AddListener(TowerInstantiate);
    }

    private void TowerInstantiate()
    {
        Instantiate<GameObject>(Tower[ImageIndex], TowerSlot.position, Quaternion.identity);
    }

    private void OnButtonClick(int index)
    {
        ImageIndex = index;
        targetImage.sprite = images[index];

        switch (ImageIndex)
        {
            case 0:
                TowerName.text = "������ Ÿ��";
                TowerPower.text = "���ݷ� 20";
                TowerSpeed.text = "����";
                TowerExplanation.text = "�⺻���� Ÿ���̴�";
                break;

            case 1:
                TowerName.text = "���� Ÿ��";
                TowerPower.text = "���ݷ� 40";
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
