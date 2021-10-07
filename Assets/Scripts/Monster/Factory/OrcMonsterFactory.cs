using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MONSTER_ORC
{

}

public class OrcMonsterFactory : MonsterFactory
{
    // 슬라임과 관련된 객체를 멤버변수로 가진다.
    [SerializeField]
    private GameObject orcPrefab = null;

    protected override Monster Create()
    {
        Orc orc = null;
        orc = Instantiate(this.orcPrefab).GetComponent<Orc>();

        return orc;
    }
}
