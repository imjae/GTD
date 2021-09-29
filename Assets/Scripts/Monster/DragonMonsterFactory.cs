using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MONSTER_DRAGON
{

}

public class DragonMonsterFactory : MonsterFactory
{
    // �����Ӱ� ���õ� ��ü�� ��������� ������.
    [SerializeField]
    private GameObject dragonPrefab = null;

    protected override Monster Create()
    {
        Dragon dragon = null;
        dragon = Instantiate(this.dragonPrefab).GetComponent<Dragon>();

        return dragon;
    }
}