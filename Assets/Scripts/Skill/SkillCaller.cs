using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    // ������ ����� ��ų�� �����ϴ� ���� ��ũ��Ʈ

public class SkillCaller : MonoBehaviour
{
    public GameObject skill;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
    // ��ų�� ����ϸ� Ÿ���ð� ���� ��ġ�� �����
            Instantiate(skill, transform.position, Quaternion.identity);
            transform.parent.gameObject.SetActive(false);
        }    
    }
}
