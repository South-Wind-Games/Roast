using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Roasts.Base;
using Roasts.Input;
using Roasts.Skills;
using Roasts.Skills.Behaviour;
using Roasts.Skills.Data;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using static Roasts.Input.InputManager;

namespace Roasts
{
    [RequireComponent(typeof(InputManager))]
    public class RoastPlayer : SerializedMonoBehaviour, IDamageable
    {
        [ShowInInspector, ReadOnly]
        private int gold = 100;

        public int Gold
        {
            get => gold;
            set => gold = value;
        }

        #region AutoReferences

        private InputManager inputManager;

        [SerializeField, FoldoutGroup("References", -1)]
        private Animator animator;

        private void OnValidate()
        {
            if (null == animator)
                animator = GetComponent<Animator>();

            if (null == inputManager)
                inputManager = GetComponent<InputManager>();
        }

        #endregion

        #region IDamageable

        [SerializeField, BoxGroup("HP")]
        private HP hp = new HP();

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

        #region Skills

        [Serializable, DisplayAsString(true)]
        public class PlayerOwnedSkill
        {
            private SkillData data;
            public SkillData Data => data;

            private int level;

            public int Level
            {
                get => level;
                set => level = value;
            }

            public PlayerOwnedSkill(SkillData data, int level = 1)
            {
                this.data = data;
                this.level = level;
            }

            public override string ToString()
            {
                if (null == data)
                    return "INVALID SKILL";
                return $"{data.name.Replace("Data", string.Empty)} (lvl:{Level})(g: {data.goldCost})";
            }
        }

        [OdinSerialize, HideLabel, BoxGroup("Skills"),
         DictionaryDrawerSettings(KeyLabel = "", ValueLabel = "",
             DisplayMode = DictionaryDisplayOptions.ExpandedFoldout)]
        private Dictionary<SkillSlots, PlayerOwnedSkill> slotsToPlayerOwnedSkills =
            new Dictionary<SkillSlots, PlayerOwnedSkill>();

        [SerializeField, HideInInspector]
        private Dictionary<PlayerOwnedSkill, SkillSlots> playerOwnedSkillsToSlots =
            new Dictionary<PlayerOwnedSkill, SkillSlots>();

        public PlayerOwnedSkill[] OwnedSkills => slotsToPlayerOwnedSkills?.Values.ToArray();

#if UNITY_EDITOR
        [Button, FoldoutGroup("Skills/Default Skills")]
        private void SetDefaultSkills()
        {
            SkillData rocketData, selfC4;
            try
            {
                rocketData = Resources.Load<SkillData>("GameData/SkillsData/RocketData");
                selfC4 = Resources.Load<SkillData>("GameData/SkillsData/SelfC4Data");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            playerOwnedSkillsToSlots?.Clear();
            slotsToPlayerOwnedSkills?.Clear();
            inputManager.CleanRegisteredSkills();

            AddSkill(SkillSlots.Primary, rocketData);
            AddSkill(SkillSlots.Secondary, selfC4);
        }

        [Button, FoldoutGroup("Skills/Default Skills")]
        private void SetTeleport()
        {
            SkillData tpData;
            try
            {
                tpData = Resources.Load<SkillData>("GameData/SkillsData/TeleportData");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            playerOwnedSkillsToSlots?.Clear();
            slotsToPlayerOwnedSkills?.Clear();
            inputManager.CleanRegisteredSkills();

            AddSkill(SkillSlots.Primary, tpData);
        }

#endif

        public void PurchaseNewSkill(SkillData newSkill)
        {
            if (null == slotsToPlayerOwnedSkills || slotsToPlayerOwnedSkills.Count == 0)
            {
                if (newSkill.name.Contains("Rocket"))
                    AddSkill(SkillSlots.Primary, newSkill);
                else if (newSkill.name.Contains("C4"))
                    AddSkill(SkillSlots.Secondary, newSkill);
                else
                    AddSkill(SkillSlots.Extra_A1, newSkill);
            }
            else
                AddSkill(newSkill);
        }

        public void UpgradeSkill(PlayerOwnedSkill upgradedSkill, int numberOfUpgrades = 1)
        {
            upgradedSkill.Level += numberOfUpgrades;
        }

        private void AddSkill(SkillSlots slot, SkillData data, int level = 1)
        {
            if (null == slotsToPlayerOwnedSkills)
            {
                slotsToPlayerOwnedSkills = new Dictionary<SkillSlots, PlayerOwnedSkill>();
                playerOwnedSkillsToSlots = new Dictionary<PlayerOwnedSkill, SkillSlots>();
            }

            inputManager.RegisterSkill(slot);

            var playerOwnedSkill = new PlayerOwnedSkill(data, level);
            slotsToPlayerOwnedSkills[slot] = playerOwnedSkill;
            playerOwnedSkillsToSlots[playerOwnedSkill] = slot;
        }

        private void AddSkill(SkillData data, int level = 1)
        {
            AddSkill((SkillSlots) slotsToPlayerOwnedSkills.Count, data, level);
        }

        /// <summary>
        ///     This gets called from InputManager to use the SkillName stored in that particular slot.
        ///     We then ask the skillManager to give use the prefab that corresponds with that SkillName."/>
        /// </summary>
        /// <param name="slot">Which skillSlot should be used.</param>
        public void UseSkill(SkillSlots slot)
        {
            InstantiateAndUseSkill(slotsToPlayerOwnedSkills[slot]);

            // StartCoroutine(RoastSkillAnimationRoutine(slotsToPlayerOwnedSkills[slot]));
        }

        private IEnumerator RoastSkillAnimationRoutine(PlayerOwnedSkill skill)
        {
            var skillData = skill.Data;
            var skillPrefab = skillData.skillPrefab;

            if (skillData.animationType == SkillStateMachine.SkillAnimationType.None)
            {
                InstantiateAndUseSkill(skill);
            }
            else
            {
                if (skillData.animationType == SkillStateMachine.SkillAnimationType.PreAnimation ||
                    skillData.animationType == SkillStateMachine.SkillAnimationType.Both)
                {
                    animator.SetTrigger(PreAnimate);
                    animationDone = false;
                    yield return new WaitUntil(() => animationDone);

                    InstantiateAndUseSkill(skill);
                }

                if (skillData.animationType == SkillStateMachine.SkillAnimationType.PostAnimation ||
                    skillData.animationType == SkillStateMachine.SkillAnimationType.Both)
                {
                    animator.SetTrigger(PostAnimate);
                    if (skillData.animationType == SkillStateMachine.SkillAnimationType.PostAnimation)
                    {
                        animationDone = false;
                        yield return new WaitUntil(() => animationDone);
                        InstantiateAndUseSkill(skill);
                    }
                }
            }
        }

        private void InstantiateAndUseSkill(PlayerOwnedSkill skill)
        {
            InstantiateSkill(skill.Data.skillPrefab).Use(this, skill.Level); //TODO: Acá finalemente, pasan las 3 cosas nuevas :(
        }

        private SkillBase InstantiateSkill(SkillBase skillPrefab)
        {
            SkillBase instantiatedSkill = Instantiate(skillPrefab); // TODO: Spawn correctly, not this shit.

            // TODO: QUE ALGUIEN HAGA ALGO

            return instantiatedSkill;
        }

        #endregion

        #region Animations

        private bool animationDone;
        private static readonly int PreAnimate = Animator.StringToHash("PreAnimate");
        private static readonly int PostAnimate = Animator.StringToHash("PostAnimate");

        public void OnAnimationComplete()
        {
            animationDone = true;
        }

        #endregion
    }
}