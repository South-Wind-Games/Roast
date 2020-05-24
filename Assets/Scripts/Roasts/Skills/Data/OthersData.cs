using Sirenix.OdinInspector;
using UnityEngine;

namespace Roasts.Skills.Data
{
    [CreateAssetMenu(fileName = "OthersData", menuName = "GameSettings/SkillData/Create new OthersData", order = 2)]
    public class OthersData : SkillData
    {
        [TitleGroup("Skill Configuration/Others Data")]
        public float pushingDistance;

        [TitleGroup("Skill Configuration/Others Data")]
        public float radius;
    }
}