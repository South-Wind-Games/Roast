using Roasts.Skills.Behaviour;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roasts.Skills
{
    public class SkillAnimationStateMachine : SerializedStateMachineBehaviour
    {
        public enum SkillAnimationType
        {
            UseBefore,
            UseDuring,
            UseAfter
        }

        [SerializeField] private SkillAnimationType type = SkillAnimationType.UseAfter;
        [Required, SerializeField]private Skill<SkillData> skill = null;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            if (type == SkillAnimationType.UseBefore)
                skill.Use();
        }

        public void OnSkillUse()
        {
            skill.Use();
            if (type != SkillAnimationType.UseDuring)
            {
                Debug.LogWarning("Ponete el estado bien puto");
            }
        }
        
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            if (type == SkillAnimationType.UseAfter)
                skill.Use();
        }
    }
}