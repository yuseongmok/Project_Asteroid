using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour
{
    public Text txtName;
    public Text txtSentence;
    public string nextSceneName; // 다음 씬의 이름

    Queue<string> sentences = new Queue<string>();

    public Animator anim;

    public void Begin(Dialogue info)
    {
        anim.SetBool("isOpen", true);

        sentences.Clear();

        txtName.text = info.name;

        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }

        Next();
    }

    public void Next()
    {
        if (sentences.Count == 0)
        {
            End();
            return;
        }

        //textSentence.text = sentences.Dequeue();
        txtSentence.text = string.Empty;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentences.Dequeue()));



        txtSentence.text = sentences.Dequeue();

    }

    IEnumerator TypeSentence(string sentence)
    {
        foreach (var letter in sentence)
        {
            txtSentence.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void End()
    {
        anim.SetBool("isOpen", false);
        // 대화가 끝나면 다음 씬으로 이동
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("다음 씬 이름이 지정되지 않았습니다.");
        }
    }
}