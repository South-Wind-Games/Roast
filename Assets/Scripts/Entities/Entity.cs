using UnityEngine.Events;

namespace Entities
{
    public abstract class Entity : IDamageable
    {
        #region IDamageable

        private HP HP { get; }


        public bool IsAlive => HP.IsAlive;

        public float CurrentHP
        {
            get => HP.CurrentHP;
            set => HP.CurrentHP = value;
        }

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

        /// <summary>
        /// Default Entity constructor.
        /// </summary>
        /// <param name="maxHP">The maximum HP this entity can have</param>
        protected Entity(float maxHP = 100)
        {
            HP = new HP(maxHP);
        }

        protected Entity(float maxHP, float startingHP) 
        {
            HP = new HP(maxHP: maxHP, startingHP: startingHP);
        }
    }
}