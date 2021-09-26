using System.Collections.Generic;

abstract class MonsterGenerator
{
    public List<Monster> monsters = new List<Monster>();

    public List<Monster> getMonsters()
    {
        return monsters;
    }

    // Factory Method
    public abstract void CreateMonsters();
}