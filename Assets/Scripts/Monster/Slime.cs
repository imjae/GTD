using UnityEngine;

public class Slime : Monster
{
    public Slime()
    {
        type = MonsterType.Slime;
        hp = 100;
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