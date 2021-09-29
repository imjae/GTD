using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HailSkill : Skill
{
    public HailSkill()
    {
        type = SkillType.Hail;
        damage = 50;
        rate = 60;
        duration = 5;
        speed = 0.5f;
    }

    public override void Use()
    {

    }
}