using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유저가 사용하는 스킬의 목표지점을 움직이는 스크립트

public class SkillTarget : MonoBehaviour
{
    public Transform target;
    int layerMask;

    Ray ray;
    RaycastHit hit;
    public GameObject ground;
    float groundHeight;

    void Start()
    {
        // 빛이 몬스터를 통과하여 오직 땅만을 인식함
        layerMask = 1 << LayerMask.NameToLayer("Ground") | ~(1 << LayerMask.NameToLayer("Monster"));
        groundHeight = ground.transform.position.y + 1f;
    }

    void Update()
    {
        // 첫 번째 카메라가 보는 마우스 위치에 빛을 쏨
        ray = Camera.allCameras[0].ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000f, layerMask))
            target.position = new Vector3(hit.point.x, groundHeight, hit.point.z);
    }
}
