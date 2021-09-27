using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 슬라임 종류에 대한 enum
public enum MONSTER_SLIME 
{ 

}

public class SlimeMonsterFactory : MonsterFactory<MONSTER_SLIME>
{
    // 슬라임과 관련된 객체를 멤버변수로 가진다.
    [SerializeField] 
    private GameObject slimePrefab = null; 
    // [SerializeField] private GameObject goblinBigPrefab = null; 
    // [SerializeField] private GameObject goblinKingPrefab = null; 
    // MonsterFactory에서 상속받은 create 함수를 꾸며준다.

    protected override Monster Create()
    {
        Slime slime = null;
        slime = Instantiate(this.slimePrefab).GetComponent<Slime>();
        // 여기서 아시다시피 goblin은 Monster를 상속받습니다.

        return slime;
    }
    protected override Monster Create(MONSTER_SLIME _type) 
    { 
        Slime slime = null; 
        
        /*switch (_type) 
        { 
            // 매개변수로 받은 Enum변수를 기준으로 고블린 객체 생성
            case MONSTER_GOBLIN.NORMAL : goblin = Instantiate(this.goblinPrefab).GetComponent<Goblin>(); 
                break; 
            case MONSTER_GOBLIN.BIG : goblin = Instantiate(this.goblinBigPrefab).GetComponent<Goblin>(); 
                break; 
            case MONSTER_GOBLIN.KING : goblin = Instantiate(this.goblinKingPrefab).GetComponent<Goblin>(); 
                break; 
        }*/
        slime = Instantiate(this.slimePrefab).GetComponent<Slime>();
        // 여기서 아시다시피 goblin은 Monster를 상속받습니다.

        return slime; 
    }
}
