using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MONSTER_GOLEM
{

}

public class GolemMonsterFactory : MonsterFactory
{
    // �����Ӱ� ���õ� ��ü�� ��������� ������.
    [SerializeField]
    private GameObject golemPrefab = null;

    protected override Monster Create()
    {
        Golem golem = null;
        golem = Instantiate(this.golemPrefab).GetComponent<Golem>();

        return golem;
    }
}
