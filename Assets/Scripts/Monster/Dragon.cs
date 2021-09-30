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
        dropGold = 500;
        moveSpeed = 0.2f;
    }
}