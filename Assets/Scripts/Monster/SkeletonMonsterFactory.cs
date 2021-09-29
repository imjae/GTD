using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMonsterFactory : MonsterFactory
{
    // �����Ӱ� ���õ� ��ü�� ��������� ������.
    [SerializeField]
    private GameObject skeletonPrefab = null;

    protected override Monster Create()
    {
        Skeleton skeleton = null;
        skeleton = Instantiate(this.skeletonPrefab).GetComponent<Skeleton>();

        return skeleton;
    }
}
