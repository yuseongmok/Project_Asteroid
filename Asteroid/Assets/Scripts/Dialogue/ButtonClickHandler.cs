using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    public Button buttonToDisable;

    private void Start()
    {
        // 버튼 클릭 이벤트에 함수를 연결
        buttonToDisable.onClick.AddListener(DisableButton);
    }

    private void DisableButton()
    {
        // 버튼을 비활성화
        buttonToDisable.gameObject.SetActive(false);
    }
}
