using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MONSTER_DRAGON
{

}

public class DragonMonsterFactory : MonsterFactory
{
    // 슬라임과 관련된 객체를 멤버변수로 가진다.
    [SerializeField]
    private GameObject dragonPrefab = null;

    protected override Monster Create()
    {
        Dragon dragon = null;
        dragon = Instantiate(this.dragonPrefab).GetComponent<Dragon>();

        return dragon;
    }
}