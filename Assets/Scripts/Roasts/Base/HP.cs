﻿using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roasts.Base
{
    [Serializable]
    public class HP : IDamageable
    {
        [ShowInInspector, ProgressBar(0, nameof(MaxHP), ColorMember = nameof(GetHPColor)),
         InlineButton(nameof(FullyHeal))]
        private float currentHP = 100;

#if UNITY_EDITOR
        private Color GetHPColor(float value)
        {
            return Color.Lerp(Color.red, Color.green, value / MaxHP);
        }

        private void FullyHeal()
        {
            currentHP = MaxHP;
        }

        [Button(ButtonStyle.Box)]
        private void SetMaxHP(float maxHP = 100)
        {
            if(maxHP <= 0)
                return;
                
            this.maxHP = maxHP;
            currentHP = Mathf.Min(maxHP, currentHP);
        }
#endif

        private float maxHP = 100;
        public float MaxHP => maxHP;

        public bool IsAlive { get; private set; }

        public float CurrentHP
        {
            get => currentHP;
            set
            {
                currentHP = value;
                if (currentHP <= 0)
                {
                    currentHP = 0;
                    IsAlive = false;
                }
            }
        }


        public HP(float maxHP = 100)
        {
            if (maxHP < 0)
                throw new Exception("Invalid parameters for creating an Entity.");

            currentHP = this.maxHP = maxHP;

            IsAlive = currentHP > 0;
        }

        public HP(float maxHP, float startingHP)
        {
            if (maxHP < startingHP)
                throw new AttemptToSetMaxHPLowerThanHealthException();

            this.maxHP = maxHP;
            CurrentHP = startingHP;

            IsAlive = currentHP > 0;
        }

        public void TakeDamage(float damage)
        {
            if (!IsAlive)
                throw new AttemptToInteractWhenDeadException();

            if (damage < 0)
                throw new AttemptToUseNegativeAbsoluteValue();
            CurrentHP -= damage;
        }

        public void TakeHealing(float healAmount)
        {
            if (!IsAlive)
                throw new AttemptToInteractWhenDeadException();

            if (healAmount < 0)
                throw new AttemptToUseNegativeAbsoluteValue();

            CurrentHP = Mathf.Min(CurrentHP + healAmount, maxHP);
        }

        /// <summary>
        /// Revives the Entity at <see cref="healthPercentage"/> % of its original maxHP (see <see cref="HP(float)"/>).
        /// </summary>
        /// <param name="healthPercentage">% from 0f to 1f of maxHP to revive target Entity.</param>
        public void Revive(float healthPercentage)
        {
            IsAlive = true;
            CurrentHP = maxHP * healthPercentage;
        }

        public class AttemptToSetMaxHPLowerThanHealthException : Exception
        {
        }

        public class AttemptToInteractWhenDeadException : Exception
        {
        }

        public class AttemptToUseNegativeAbsoluteValue : Exception
        {
        }
    }
}