using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour
{
    public List<Button> buttons; // Button을 저장할 List 변수
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
        // 모든 Button에 클릭 이벤트를 연결
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
                TowerName.text = "레이저 타워";
                TowerPower.text = "공격력 20";
                TowerSpeed.text = "보통";
                TowerExplanation.text = "기본적인 타워이다";
                break;

            case 1:
                TowerName.text = "샷건 타워";
                TowerPower.text = "공격력 40";
                TowerSpeed.text = "느림";
                TowerExplanation.text = "두 발씩 발사하는 타워이다";
                break;

            case 2:
                TowerName.text = "기획몰라 타워";
                TowerPower.text = "공격력 10";
                TowerSpeed.text = "빠름";
                TowerExplanation.text = "아직 기획이 안된 타워이다";
                break;

            default:
                
                break;
        }
    }
}
