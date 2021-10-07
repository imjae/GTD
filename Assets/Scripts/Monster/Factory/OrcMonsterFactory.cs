using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MONSTER_ORC
{

}

public class OrcMonsterFactory : MonsterFactory
{
    // �����Ӱ� ���õ� ��ü�� ��������� ������.
    [SerializeField]
    private GameObject orcPrefab = null;

    protected override Monster Create()
    {
        Orc orc = null;
        orc = Instantiate(this.orcPrefab).GetComponent<Orc>();

        return orc;
    }
}
