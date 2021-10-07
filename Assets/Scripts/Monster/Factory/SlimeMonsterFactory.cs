using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 슬라임 종류에 대한 enum
public enum MONSTER_SLIME 
{ 

}

public class SlimeMonsterFactory : MonsterFactory
{
    // 슬라임과 관련된 객체를 멤버변수로 가진다.
    [SerializeField] 
    private GameObject slimePrefab = null;

    protected override Monster Create()
    {
        Slime slime = null;
        slime = Instantiate(this.slimePrefab).GetComponent<Slime>();

        return slime;
    }
}
