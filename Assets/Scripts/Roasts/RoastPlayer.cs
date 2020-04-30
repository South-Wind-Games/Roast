using Players;
using UnityEngine;

namespace Roasts
{
    public class RoastPlayer : MonoBehaviour, IDamageable
    {
        [SerializeField] private HP hp = new HP();

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
    }
}