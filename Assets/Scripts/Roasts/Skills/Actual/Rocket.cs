using Roasts.Skills.Behaviour;
using Roasts.Skills.Data;
using UnityEngine;

namespace Roasts.Skills.Actual
{
    public class Rocket : Skill<ProjectileData>
    {
        protected override void OnSkillUse(
            Vector3 aimDirection = new Vector3(),
            Vector3 faceDirection = new Vector3())
        {
        }
    }
}