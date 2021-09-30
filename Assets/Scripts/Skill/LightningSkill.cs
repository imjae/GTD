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
    }

    public override void Use()
    {

    }
}