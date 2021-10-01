using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    // 유저가 사용할 스킬을 구현하는 복사 스크립트

public class SkillCaller : MonoBehaviour
{
    public GameObject skill;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
    // 스킬을 사용하면 타겟팅과 복사 장치가 종료됨
            Instantiate(skill, transform.position, Quaternion.identity);
            transform.parent.gameObject.SetActive(false);
        }    
    }
}
