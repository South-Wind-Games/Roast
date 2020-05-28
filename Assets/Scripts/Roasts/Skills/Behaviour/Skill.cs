using Roasts.Skills.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roasts.Skills.Behaviour
{
    public abstract class Skill<T> : SkillBase where T : SkillData
    {
        [SerializeField, InlineEditor]
        protected T data;

        [ShowInInspector, ReadOnly, ShowIf(nameof(IsApplicationRunning))]
        protected RoastPlayer Owner;

        protected int CurrentLevel { get; private set; } = 1;

        [Button, ShowIf(nameof(IsApplicationRunning))]
        public void Use(RoastPlayer owner, int level)
        {  Owner = GetComponentInParent<RoastPlayer>(); //Esto es Para probar los skills. Hay que codear que siempre que se instacie un skill sea hijo del player. PD puto el que lee!
           // Owner = owner;
            CurrentLevel = level;
            OnSkillUse();
        }

        private bool IsApplicationRunning()
        {
            return Application.isPlaying;
        }

        protected abstract void OnSkillUse();
    }
}