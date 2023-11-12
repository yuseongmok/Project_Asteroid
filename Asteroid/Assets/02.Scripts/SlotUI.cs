using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotUI : MonoBehaviour
{
    public List<Button> buttonList; // Button�� ������ List ����
    public GameObject uiPanel; // Ȱ��ȭ�� UI â
    public SoundManager soundManager;

    private void Start()
    {
        // Button���� List�� �߰�
        buttonList = new List<Button>(GetComponentsInChildren<Button>());

        // �� Button�� Ŭ�� �̺�Ʈ�� ����
        foreach (Button button in buttonList)
        {
            button.onClick.AddListener(() => ToggleUIPanel());
        }

        // UI �г��� �ʱ⿡ ��Ȱ��ȭ
        uiPanel.SetActive(false);
    }

    // UI �г��� Ȱ��ȭ/��Ȱ��ȭ�ϴ� �Լ�
    void ToggleUIPanel()
    {
        uiPanel.SetActive(!uiPanel.activeSelf);
        soundManager.PlaySound(0);
    }
}
