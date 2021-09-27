using UnityEngine;
public enum MonsterType
{
    Slime,
    TurtleShell,
    Bat,
    Spider,
    MonsterPlant,
    Skeleton,
    Dragon,
    Orc,
    EvilMage,
    Golem
}

public abstract class Monster : MonoBehaviour
{
    public MonsterType type;
    public int hp;
    public int damage;

    public float moveSpeed;
    public abstract void Move();
    public abstract void Die();
}