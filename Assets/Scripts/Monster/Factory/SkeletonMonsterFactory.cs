using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMonsterFactory : MonsterFactory
{
    // 슬라임과 관련된 객체를 멤버변수로 가진다.
    [SerializeField]
    private GameObject skeletonPrefab = null;

    protected override Monster Create()
    {
        Skeleton skeleton = null;
        skeleton = Instantiate(this.skeletonPrefab).GetComponent<Skeleton>();

        return skeleton;
    }
}
