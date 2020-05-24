using Sirenix.OdinInspector;
using UnityEngine;

namespace Roasts.Skills.Data
{
    [CreateAssetMenu(fileName = "NewProjectile", menuName = "GameSettings/SkillData/Create new ProjectileData",
        order = 1)]
    public class ProjectileData : SkillData
    {
        [TitleGroup("Skill Configuration/Projectile Data")]
        public float speed = 1;
    }
}