using UnityEngine;

namespace Roasts.Skills.Data
{
    [CreateAssetMenu(fileName = "NewProjectile", menuName = "GameSettings/SkillData/Create new ProjectileData", order = 1)]
    public class ProjectileData : SkillData
    {
        public float speed = 1;
    }
}