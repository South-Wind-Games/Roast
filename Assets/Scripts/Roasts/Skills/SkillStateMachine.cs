using Sirenix.OdinInspector;
using UnityEngine;

namespace Roasts.Skills
{
    public class SkillStateMachine : SerializedStateMachineBehaviour
    {
        public enum SkillAnimationType
        {
            PreAnimation,
            PostAnimation,
            Both,
            None
        }

        [Required, SerializeField]
        private RoastPlayer player;

        [SerializeField]
        private SkillAnimationType type = SkillAnimationType.PreAnimation;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);

            if (null == player)
                player = animator.gameObject.GetComponent<RoastPlayer>();

            if (type != SkillAnimationType.PreAnimation)
                player.OnAnimationComplete();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);

            if (type != SkillAnimationType.PostAnimation)
                player.OnAnimationComplete();
        }
    }
}