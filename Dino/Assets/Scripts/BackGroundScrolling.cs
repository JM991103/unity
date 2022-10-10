using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackGroundScrolling : MonoBehaviour
{
    // ����� �����̴� �ӵ�
    public float scrollingSpeed = 5.0f;

    // ��� �̹����� ���� ����
    public float widht = 5.5f;      //Ground�� 3.0f sky�� 5.5f

    // ��� �̹��� ������Ʈ���� Ʈ������
    Transform[] bgSlot;

    // �̹����� �ݴ������� �Ѿ ��ġ(����� �������� �̵��� ����)
    float endPoint;

    private void Awake()
    {

        bgSlot = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            bgSlot[i] = transform.GetChild(i);
        }

    }

    private void Start()
    {
        endPoint = transform.position.x - widht;
    }

    private void Update()
    {
        foreach(var slot in bgSlot)
        {
            slot.Translate(scrollingSpeed * Time.deltaTime * -transform.right);
            if (slot.position.x < endPoint)
            {
                slot.Translate(widht * bgSlot.Length * transform.right);
            }
        }
    }

}
