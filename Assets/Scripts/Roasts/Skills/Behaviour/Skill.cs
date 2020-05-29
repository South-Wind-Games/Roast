using Roasts.Skills.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roasts.Skills.Behaviour
{
    public abstract class Skill<T> : SkillBase where T : SkillData
    {
        [SerializeField, InlineEditor]
        protected T data;
    }
}