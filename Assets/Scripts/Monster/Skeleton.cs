using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Monster
{
    public Skeleton()
    {
        type = MonsterType.Skeleton;
        hp = 200;
        damage = 10;

        moveSpeed = 0.1f;
    }

    public override void Move()
    {
    }
    public override void Die()
    {

    }
}