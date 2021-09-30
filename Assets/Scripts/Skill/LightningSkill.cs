using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSkill : Skill
{
    public LightningSkill()
    {
        type = SkillType.Lightning;
        damage = 45;
        rate = 30;
        duration = 1;
        speed = 0.1f;
    }

    public override void Use()
    {

    }
}