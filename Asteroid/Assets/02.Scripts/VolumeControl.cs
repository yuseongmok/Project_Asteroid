using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider; // Inspector에서 할당할 Slider UI 요소
    public List<AudioSource> audioSources; // Inspector에서 할당할 AudioSource 리스트

    void Start()
    {
        // 초기 볼륨을 Slider의 초기값으로 설정
        if (volumeSlider != null && audioSources != null)
        {
            volumeSlider.value = audioSources[0].volume; // 여기서는 첫 번째 AudioSource의 볼륨을 초기값으로 설정했습니다.
        }

        // Slider의 값이 변경될 때 이벤트 리스너 등록
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
        }
    }

    // 볼륨을 변경하는 함수
    void ChangeVolume(float volume)
    {
        // 모든 AudioSource의 볼륨을 변경
        foreach (var audioSource in audioSources)
        {
            if (audioSource != null)
            {
                audioSource.volume = volume;
            }
        }
    }
}
