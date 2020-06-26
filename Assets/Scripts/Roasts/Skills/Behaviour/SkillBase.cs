using Sirenix.OdinInspector;
using UnityEngine;

namespace Roasts.Skills.Behaviour
{
    public abstract class SkillBase : MonoBehaviour
    {
        [ShowInInspector, ReadOnly, ShowIf(nameof(IsApplicationRunning))]
        protected RoastPlayer owner;

        #region Static local player references
        //TODO: Should this shit be on something like NetworkManager somethin'?

        private static RoastPlayer localPlayer = null;

        public static RoastPlayer LocalPlayer
        {
            get
            {
                if (null == localPlayer)
                {
                    localPlayer = FindObjectOfType<RoastPlayer>(); //TODO: Make RoastPlayer a SerializedSingleton<T>
                }

                return localPlayer;
            }
        }


        private static Rigidbody localPlayersRB = null;

        public static Rigidbody LocalPlayersRB
        {
            get
            {
                if (null == localPlayersRB)
                {
                    localPlayersRB = LocalPlayer.GetComponent<Rigidbody>();
                }

                return localPlayersRB;
            }
        }

        #endregion

        protected int CurrentLevel { get; private set; } = 1;

        [Button, ShowIf(nameof(IsApplicationRunning))]
        public void Use(RoastPlayer skillOwner, int level)
        {
            owner = skillOwner;
            CurrentLevel = level;
            OnSkillUse();
        }

        protected abstract void OnSkillUse(
            Vector3 aimDirection = new Vector3(),
            Vector3 facingDirection = new Vector3());

#if UNITY_EDITOR
        private bool IsApplicationRunning()
        {
            return Application.isPlaying;
        }
#endif
    }
}