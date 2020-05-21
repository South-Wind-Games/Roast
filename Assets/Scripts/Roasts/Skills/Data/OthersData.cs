using UnityEngine;

namespace Roasts.Skills.Data
{
    [CreateAssetMenu(fileName = "OthersData", menuName = "GameSettings/SkillData/Create new OthersData", order = 2)]
    public class OthersData : SkillData
    {
        public float radius;
        public float pushingDistance;
    }
}
