using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    // 목표지점의 이미지가 회전해 역동감을 주는 스크립트

public class SpriteRotation : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, speed);   
    }
}
