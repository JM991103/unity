using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackGroundScrolling : MonoBehaviour
{
    // 배경이 움직이는 속도
    public float scrollingSpeed = 5.0f;

    // 배경 이미지의 가로 길이
    public float widht = 5.5f;      //Ground는 3.0f sky는 5.5f

    // 배경 이미지 오브젝트들의 트랜스폼
    Transform[] bgSlot;

    // 이미지가 반대쪽으로 넘어갈 위치(충분히 왼쪽으로 이동한 지점)
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
