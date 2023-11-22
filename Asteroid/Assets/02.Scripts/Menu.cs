using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuCanvas;      //�޴�â ������Ʈ
    public Button GoStartButton;             //����ϱ� ��ư
    public Button RePlay;                   //�ٽ��ϱ� ��ư
    public Button EndButton;                //�������� ��ư

    //���� �Ŵ���
    public SoundManager soundManager;

    void Start()
    {
        pauseMenuCanvas.SetActive(false);
        GoStartButton.onClick.AddListener(GoStart);
        RePlay.onClick.AddListener(ReStart);
        EndButton.onClick.AddListener(EndGame);
    }

    void Update()
    {
        // EscŰ ������ ��
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
                
            }
            else
            {
                Pause();
               
            }
        }

        
    }

    // EscŰ ������ �޴�â ���� �Լ�
    public void Resume()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("Game ����ϱ�");
        soundManager.PlaySound(3);
    }

    // �ٽ� EscŰ ������ �޴�â ����� �Լ�
    public void Pause()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Debug.Log("Game �Ͻ�����");
        soundManager.PlaySound(3);
    }

    // �޴�â���� ����ϱ� ��ư�� ������ �� �����ϴ� �ڵ�
    public void GoStart()
    {
        Time.timeScale = 1f;
        pauseMenuCanvas.SetActive(false);
        GameIsPaused = false;
        Debug.Log("Game ����ϱ�");
        soundManager.PlaySound(3);
    }

    // �޴�â���� �ٽ��ϱ� ��ư�� ������ �� �����ϴ� �ڵ�
    public void ReStart()
    {
        SceneManager.LoadScene("Play");
        Time.timeScale = 1f;
        Debug.Log("Play Scene �ٽý���");
    }

    public void EndGame()
    {
        Application.Quit();
        Debug.Log("��������");
        soundManager.PlaySound(3);
    }


}
