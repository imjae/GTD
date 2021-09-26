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

abstract class Monster
{
    protected MonsterType type;
    protected string name;
    protected int hp;
    protected int damage;

    protected float moveSpeed;
    public abstract void Move();
    public abstract void Die();
}