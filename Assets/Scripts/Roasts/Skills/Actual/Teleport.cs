using System;
using Roasts.Skills.Behaviour;
using Roasts.Skills.Data;
using UnityEngine;

namespace Roasts.Skills.Actual
{
    public class Teleport : Skill<SkillData>
    {
        protected override void OnSkillUse()
        {
            Debug.Log($"Me movi {data.significantAmount * data.levelIncreaseCurves[0].Evaluate(CurrentLevel * .1f)}");
        }
    }
}