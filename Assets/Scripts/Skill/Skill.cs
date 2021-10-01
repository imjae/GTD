using UnityEngine;

public enum SkillType
{
    Fire,
    Lightning,
    Hail
}

public abstract class Skill : MonoBehaviour
{
    public SkillType type;
    public int damage;
    public int rate;
    public abstract void Use();
}
