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
    }

    public override void Use()
    {

    }
}
