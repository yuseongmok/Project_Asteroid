using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayScenes : MonoBehaviour
{
    public int targetSceneIndex; // ��ȯ�� ���� ���� �ε����� �ν����Ϳ��� ������ �� �ֵ��� ������ �����մϴ�.

    public void LoadNextScene()
    {
        LoadingScene.LoadScene("Story01");
    }
}