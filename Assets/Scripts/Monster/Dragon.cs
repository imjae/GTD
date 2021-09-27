using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Monster
{
    public Dragon()
    {
        type = MonsterType.Dragon;
        hp = 1000;
        damage = 10;

        moveSpeed = 0.2f;
    }

    public override void Move()
    {
    }
    public override void Die()
    {

    }
}