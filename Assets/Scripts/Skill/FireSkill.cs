using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkill : Skill
{
    public FireSkill()
    {
        type = SkillType.Fire;
        damage = 30;
        rate = 30;
        duration = 3;
        speed = 0.5f;
    }

    public override void Use()
    {

    }
}