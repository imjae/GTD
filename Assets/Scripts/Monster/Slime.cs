using UnityEngine;

public class Slime : Monster
{
    public Slime()
    {
        type = MonsterType.Slime;
        hp = 100;
        damage = 10;
        dropGold = 100;
        moveSpeed = 0.1f;
    }
}