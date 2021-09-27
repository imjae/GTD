using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 슬라임 종류에 대한 enum
public enum MONSTER_SKELETON
{

}

public class SkeletonMonsterFactory : MonsterFactory<MONSTER_SKELETON>
{
    // 슬라임과 관련된 객체를 멤버변수로 가진다.
    [SerializeField]
    private GameObject skeletonPrefab = null;
    // [SerializeField] private GameObject goblinBigPrefab = null; 
    // [SerializeField] private GameObject goblinKingPrefab = null; 
    // MonsterFactory에서 상속받은 create 함수를 꾸며준다.

    protected override Monster Create()
    {
        Skeleton skeleton = null;
        skeleton = Instantiate(this.skeletonPrefab).GetComponent<Skeleton>();
        // 여기서 아시다시피 goblin은 Monster를 상속받습니다.

        return skeleton;
    }
    protected override Monster Create(MONSTER_SKELETON _type)
    {
        Skeleton skeleton = null;

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
        skeleton = Instantiate(this.skeletonPrefab).GetComponent<Skeleton>();
        // 여기서 아시다시피 goblin은 Monster를 상속받습니다.

        return skeleton;
    }
}
