using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public List<string> dialogueList;
    private int currentIndex;
    private bool isTyping;
    
    public GameObject Ob;

    public Sprite[] images;
    public Image targetImage;
    public int ImageIndex = 0;

    public GameObject warring;
    //���� �Ŵ���
    public SoundManager soundManager;

    public Button SkipButton;

    private void Start()
    {
        currentIndex = 0;
        isTyping = false;
        dialogueText.text = "";
        Ob.SetActive(false);
        warring.SetActive(false);
        SkipButton.onClick.AddListener(Skip);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Ob.SetActive(true);
            
            if (isTyping)
            {
                // ��ȭ �ؽ�Ʈ�� ���� ��� ǥ�õ��� �ʾ��� ��, �ؽ�Ʈ�� �ٷ� ǥ���ϰ� �ִϸ��̼��� ������
                CompleteTyping();
                
            }
            else
            {
                ShowNextDialogue();
            }
        }


    }

    public void Skip()
    {
        SceneManager.LoadScene("Play");
    }

    void ShowNextDialogue()
    {
        if (currentIndex < dialogueList.Count)
        {
            StartCoroutine(TypeDialogue(dialogueList[currentIndex]));
            currentIndex++;
        }
        else
        {
            // ��ȭ�� ��� ǥ�õǸ� ��ȭ UI�� ��Ȱ��ȭ�ϰų� �ٸ� ������ ������ �� ����
            // ���� ���, ��ȭ UI�� ���� �� �ֽ��ϴ�.
            // gameObject.SetActive(false);
        }
    }

    // ��簡 ������ �ڵ�
    IEnumerator TypeDialogue(string text)
    {
        ImageIndex++; // �̹��� �ε����� ������Ű�� �̹����� �����մϴ�
        ChangeImage(); // �̹����� �����ϴ� �Լ��� ȣ���մϴ�
        
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.1f); // �� ���ھ� ǥ�õǴ� �ð��� ����
        }

        isTyping = false;
        
       
    }

    

    

    void ChangeImage()
    {
        // �̹��� ü����
        if (ImageIndex == 2 || ImageIndex == 8)
        {
            targetImage.sprite = images[1];
        }

        
        // warring �̹����� ���� ������ ����
        if (ImageIndex == 5)
        {
            soundManager.PlaySound(0);
            warring.SetActive(true);
            targetImage.sprite = images[0];
        }

       if(ImageIndex == 11)
       {
            LoadingScene.LoadScene("Play");
       }
    }

    void CompleteTyping()
    {
        // ��� ���ڸ� �� ���� ǥ���ϰ� �ִϸ��̼��� ����
        StopAllCoroutines();
        dialogueText.text = dialogueList[currentIndex - 1];
        isTyping = false;
    }
}
