using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScenes : MonoBehaviour
{
    public int targetSceneIndex; // 전환할 다음 씬의 인덱스를 인스펙터에서 설정할 수 있도록 변수를 선언합니다.

    public void LoadNextScene()
    {
        SceneManager.LoadScene(targetSceneIndex); // 다음 씬으로 전환합니다.
    }
}