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
        dropGold = 400;
        moveSpeed = 0.2f;
    }
}