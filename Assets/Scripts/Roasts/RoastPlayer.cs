using Players;
using UnityEngine;

namespace Roasts
{
    public class RoastPlayer : IDamageable
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

        private void Start()
        {
            roastRenderer.material.color = Random.ColorHSV(0, 1);
        }
    }
}