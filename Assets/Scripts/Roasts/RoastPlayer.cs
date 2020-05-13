using Mirror;
using Roasts.Base;
using UnityEngine;

namespace Roasts
{
    public class RoastPlayer
#if ROAST_NETWORKING_ENABLED
        : Mirror.NetworkBehaviour
#else
        : MonoBehaviour
#endif
            , IDamageable
    {
        [SerializeField] private HP hp = new HP();

        [SerializeField] private Renderer roastRenderer = null;

        #region IDamageable

        private HP HP => hp;

        public bool IsAlive => HP.IsAlive;

        public float CurrentHP
        {
            get => HP.CurrentHP;
            set => HP.CurrentHP = value;
        }

        public float MaxHP => HP.MaxHP;

        public void TakeDamage(float damage)
        {
            HP.TakeDamage(damage);
        }

        public void TakeHealing(float healAmount)
        {
            HP.TakeHealing(healAmount);
        }

        public void Revive(float healthPercentage)
        {
            HP.Revive(healthPercentage);
        }

        #endregion

#if ROAST_NETWORKING_ENABLED
        [SyncVar] private Color playerColor;

        public override void OnStartServer()
        {
            base.OnStartServer();
            playerColor = Random.ColorHSV(0f, 1f, 0.9f, 0.9f, 1f, 1f);
        }

        public override void OnStartClient()
        {
            base.OnStartClient();

            roastRenderer.material.color = playerColor;
        }
#endif
    }
}