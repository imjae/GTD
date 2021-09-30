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
    }

    public override void Use()
    {

    }
}