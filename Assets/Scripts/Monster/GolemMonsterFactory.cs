using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MONSTER_GOLEM
{

}

public class GolemMonsterFactory : MonsterFactory
{
    // 슬라임과 관련된 객체를 멤버변수로 가진다.
    [SerializeField]
    private GameObject golemPrefab = null;

    protected override Monster Create()
    {
        Golem golem = null;
        golem = Instantiate(this.golemPrefab).GetComponent<Golem>();

        return golem;
    }
}
