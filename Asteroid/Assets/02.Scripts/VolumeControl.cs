using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider; // Inspector���� �Ҵ��� Slider UI ���
    public List<AudioSource> audioSources; // Inspector���� �Ҵ��� AudioSource ����Ʈ
    public Sprite[] images;
    public Image targetImage;

    void Start()
    {
        // �ʱ� ������ Slider�� �ʱⰪ���� ����
        if (volumeSlider != null && audioSources != null)
        {
            volumeSlider.value = audioSources[0].volume; // ���⼭�� ù ��° AudioSource�� ������ �ʱⰪ���� �����߽��ϴ�.
        }

        // Slider�� ���� ����� �� �̺�Ʈ ������ ���
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
        }
    }

    // ������ �����ϴ� �Լ�
    void ChangeVolume(float volume)
    {
        // ��� AudioSource�� ������ ����
        foreach (var audioSource in audioSources)
        {
            if (audioSource != null)
            {
                audioSource.volume = volume;

                // ������ 0�̸� Ÿ�� �̹��� ����
                if (volume == 0 && targetImage.depth > 1)
                {
                    targetImage.sprite = images[1];
                }
                else if (volume > 0 && targetImage.depth > 0)
                {
                    targetImage.sprite = images[0];
                }
            }
        }
    }
}
