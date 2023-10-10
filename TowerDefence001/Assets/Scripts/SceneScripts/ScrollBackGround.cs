using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackGround : MonoBehaviour
{
    public float scrollSpeed;                                               // ���ư��� �ӵ� ����
    public Renderer rend;                                                   // ����(����) ����

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();                                    // ���忡 ������ ��������
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;                             //offset�� �ӵ� *�ð� (Time.deltatime�� ���� �ʴ� ������ ��� ���� ��쿡�� �ӵ��� �߿����� �ʱ� �����̴�) ����
        rend.material.mainTextureOffset = new Vector2(offset, 0);           // ���忡 ���͸����� �ؽ��Ŀ�  X�࿡ Offset ����
    }
}

