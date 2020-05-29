using Sirenix.OdinInspector;
using UnityEngine;

namespace Roasts.Skills.Behaviour
{
    public abstract class SkillBase : MonoBehaviour
    {
        [ShowInInspector, ReadOnly, ShowIf(nameof(IsApplicationRunning))]
        protected RoastPlayer Owner;

        protected int CurrentLevel { get; private set; } = 1;

        [Button, ShowIf(nameof(IsApplicationRunning))]
        public void Use(RoastPlayer owner, int level)
        {
            Owner = owner;
            CurrentLevel = level;
            OnSkillUse();
        }

        protected abstract void OnSkillUse();

#if UNITY_EDITOR
        private bool IsApplicationRunning()
        {
            return Application.isPlaying;
        }
#endif
    }
}