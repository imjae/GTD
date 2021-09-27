using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Monster
{
    public Golem()
    {
        type = MonsterType.Golem;
        hp = 400;
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