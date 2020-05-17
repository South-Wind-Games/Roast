using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roasts.Skills.Actual
{
    [Serializable]
    public class Teleport : Skill<SkillData>
    {
        [Button]
        public override void Use()
        {
            Debug.Log($"Me movi {data.significantAmount * data.levelIncreaseCurves[0].Evaluate(currentLevel * .1f)}");
        }
    }
}