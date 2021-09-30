using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Monster
{
    public Orc()
    {
        type = MonsterType.Orc;
        hp = 300;
        damage = 10;
        dropGold = 300;
        moveSpeed = 0.1f;
    }
}