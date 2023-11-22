using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager2 : MonoBehaviour
{
    public Text dialogueText;
    public List<string> dialogueList;
    private int currentIndex;
    private bool isTyping;
    
    
    public GameObject Tutorial;

    public Sprite[] images;
    public Sprite[] images2;
    public Image targetImage;
    public Image targetImage2;
    
    public int ImageIndex = 0;
    private bool TutorialBool = false;

    public Button SkipButton;

    private void Start()
    {
        currentIndex = 0;
        isTyping = false;
        dialogueText.text = "";
        
        Tutorial.SetActive(false);
        TutorialBool = true;
        SkipButton.onClick.AddListener(ButtonClick);
    }

    private void Update()
    {
        
        //Ʃ�丮�� ���� �� ��
        if (TutorialBool)
        {
            //���콺 ���� Ŭ���ϰų� �����̽��ٸ� ���� ��
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {

                Tutorial.SetActive(true);
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
    }

    public void ButtonClick()
    {
        if (Tutorial != null)
        {
            Tutorial.SetActive(false);
            TutorialBool = false;
        }

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
        targetImage2.sprite = images2[ImageIndex];
        // �̹��� ü����
        if (ImageIndex == 3)
        {
            targetImage.sprite = images[0];
        }

        if (ImageIndex == 15)
        {
            Tutorial.SetActive(false);
            TutorialBool = false;
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
