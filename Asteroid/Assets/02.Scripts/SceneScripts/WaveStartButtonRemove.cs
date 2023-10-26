using UnityEngine;
using UnityEngine.UI;

public class WaveStartButtonRemove : MonoBehaviour
{
    public Button button; // ��ư GameObject�� ������ ��ư ������Ʈ
    public Image image;   // �̹����� ǥ���� GameObject�� ������ �̹��� ������Ʈ

    private bool isButtonActive = true; // ��ư ���¸� ����

    void Start()
    {
        // ��ư Ŭ�� �̺�Ʈ�� �Լ� ����
        button.onClick.AddListener(ToggleButtonState);
    }

    void ToggleButtonState()
    {
        isButtonActive = !isButtonActive;

        // ��ư ���¿� ���� ��ư Ȱ��ȭ/��Ȱ��ȭ ����
        button.interactable = isButtonActive;

        // ��ư ���¿� ���� �̹��� ǥ��/���� ����
        image.gameObject.SetActive(isButtonActive);
    }
}