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

    public List<int> towerCosts;

    void Start()
    {
        // 모든 Button에 클릭 이벤트를 연결
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(() => OnButtonClick(buttons.IndexOf(btn)));
        }
        tower.onClick.AddListener(TowerInstantiate);
    }

    //상점 구매하기 버튼 누르면 실행하는 함수
    private void TowerInstantiate()
    { 
        int towerCost = towerCosts[ImageIndex];

        // 현재 돈을 가져오는 로직 (MoneyManager에 있는 Money 변수를 활용)
        int currentMoney = MoneyManager.Instance.Money;

        // 충분한 돈이 있는지 확인
        if (currentMoney >= towerCost)
        {
            // 충분한 돈이 있다면 타워 설치 가능
            Instantiate<GameObject>(Tower[ImageIndex], TowerSlot.position, Quaternion.identity);

            // 타워 비용만큼 돈 차감
            MoneyManager.Instance.SpendMoney(towerCost);
        }
        else
        {
            Debug.Log("돈이 부족해요");
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
                TowerName.text = "레이저 타워";
                TowerPower.text = "공격력 100";
                TowerSpeed.text = "보통";
                TowerExplanation.text = "기본적인 타워이다";
                break;

            case 1:
                TowerName.text = "샷건 타워";
                TowerPower.text = "공격력 200";
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
