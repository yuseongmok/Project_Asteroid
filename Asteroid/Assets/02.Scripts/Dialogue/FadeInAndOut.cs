using UnityEngine;
using System.Collections;
using UnityEditor.Build.Content;

public class FadeInAndOut : MonoBehaviour
{
    public float fadeDuration = 2.0f; // ��Ÿ���� ������� �� �ɸ��� �ð�
    
    private CanvasRenderer canvasRenderer;
    
   

    void OnEnable()
    {
        canvasRenderer = GetComponent<CanvasRenderer>();
        StartCoroutine(FadeInOut());
        
    }

    
    IEnumerator FadeInOut()
    {
        while (true)
        {
            // �̹��� ������ ��Ÿ����
            for (float t = 0; t < fadeDuration; t += Time.deltaTime)
            {
                canvasRenderer.SetAlpha(t / fadeDuration);
                yield return null;
            }

            // �̹��� ������ �������
            for (float t = fadeDuration; t > 0; t -= Time.deltaTime)
            {
                canvasRenderer.SetAlpha(t / fadeDuration);
                yield return null;
            }
        }
    }

    private void OnDisable()
    {
        StopCoroutine(FadeInOut());
    }


}
