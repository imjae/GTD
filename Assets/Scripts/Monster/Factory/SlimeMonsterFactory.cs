using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ������ ���� enum
public enum MONSTER_SLIME 
{ 

}

public class SlimeMonsterFactory : MonsterFactory
{
    // �����Ӱ� ���õ� ��ü�� ��������� ������.
    [SerializeField] 
    private GameObject slimePrefab = null;

    protected override Monster Create()
    {
        Slime slime = null;
        slime = Instantiate(this.slimePrefab).GetComponent<Slime>();

        return slime;
    }
}
