using System;
using System.Collections;
using System.Collections.Generic;
using Roasts.Base;
using Roasts.Skills;
using Roasts.Skills.Behaviour;
using Roasts.Skills.Data;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using static Roasts.Input.InputManager;

namespace Roasts
{
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

        private void OnValidate()
        {
            if (null == animator)
                animator = GetComponent<Animator>();
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

        [Serializable]
        public struct PlayerOwnedSkill
        {
            public SkillData data;
            public int level;

            public PlayerOwnedSkill(SkillData data, int level = 1)
            {
                this.data = data;
                this.level = level;
            }
        }


        [SerializeField, BoxGroup("Skills"),
         DictionaryDrawerSettings(KeyLabel = "", ValueLabel = "",
             DisplayMode = DictionaryDisplayOptions.ExpandedFoldout)]
        private Dictionary<SkillSlots, PlayerOwnedSkill> ownedSkills = new Dictionary<SkillSlots, PlayerOwnedSkill>();

        public Dictionary<SkillSlots, PlayerOwnedSkill> OwnedSkills => ownedSkills;


#if UNITY_EDITOR
        [Button, FoldoutGroup("Skills/Set this player's skills")]
        private void SetDefaultSkills()
        {
            SkillData rocketData, selfC4;
            try
            {
                rocketData =
                    AssetDatabase.LoadAssetAtPath<SkillData>("Assets/Resources/SkillsData/RocketData.asset");
                selfC4 =
                    AssetDatabase.LoadAssetAtPath<SkillData>("Assets/Resources/SkillsData/SelfC4Data.asset");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            ownedSkills?.Clear();

            AddSkill(SkillSlots.Primary, rocketData);
            AddSkill(SkillSlots.Secondary, selfC4);
        }
#endif


        //TODO: Create editor script
        public void GiveOrUpgradeSkill(SkillData skillData)
        {
            foreach (var keyValuePair in ownedSkills)
            {
                if (keyValuePair.Value.data == skillData)
                {
                    AddSkill(keyValuePair.Key, skillData, keyValuePair.Value.level + 1);
                    return;
                }
            }

            AddSkill((SkillSlots) ownedSkills.Count, skillData);
        }

        private void AddSkill(SkillSlots slot, SkillData data, int level = 1)
        {
            if (null == ownedSkills)
                ownedSkills = new Dictionary<SkillSlots, PlayerOwnedSkill>();

            ownedSkills[slot] = new PlayerOwnedSkill(data, level);
        }

        /// <summary>
        ///     This gets called from InputManager to use the SkillName stored in that particular slot.
        ///     We then ask the skillManager to give use the prefab that corresponds with that SkillName."/>
        /// </summary>
        /// <param name="slot">Which skillSlot should be used.</param>
        public void UseSkill(SkillSlots slot)
        {
            StartCoroutine(RoastSkillAnimationRoutine(ownedSkills[slot]));
        }

        private IEnumerator RoastSkillAnimationRoutine(PlayerOwnedSkill skill)
        {
            var skillData = skill.data;
            var skillPrefab = skillData.skillPrefab;

            if (skillData.animationType == SkillStateMachine.SkillAnimationType.None)
            {
                InstantiateAndUseSkill(skill, skillPrefab);
            }
            else
            {
                if (skillData.animationType == SkillStateMachine.SkillAnimationType.PreAnimation ||
                    skillData.animationType == SkillStateMachine.SkillAnimationType.Both)
                {
                    animator.SetTrigger(PreAnimate);
                    animationDone = false;
                    yield return new WaitUntil(() => animationDone);

                    InstantiateAndUseSkill(skill, skillPrefab);
                }

                if (skillData.animationType == SkillStateMachine.SkillAnimationType.PostAnimation ||
                    skillData.animationType == SkillStateMachine.SkillAnimationType.Both)
                {
                    animator.SetTrigger(PostAnimate);
                    if (skillData.animationType == SkillStateMachine.SkillAnimationType.PostAnimation)
                    {
                        animationDone = false;
                        yield return new WaitUntil(() => animationDone);
                        InstantiateAndUseSkill(skill, skillPrefab);
                    }
                }
            }
        }

        private void InstantiateAndUseSkill(PlayerOwnedSkill skill, SkillBase skillPrefab)
        {
            InstantiateSkill(skillPrefab).Use(this, skill.level);
        }

        private SkillBase InstantiateSkill(SkillBase skillPrefab)
        {
            SkillBase instantiatedSkill = Instantiate(skillPrefab); // TODO: Spawn correctly, not this shit.

            // TODO: QUE ALGUIEN HAGA ALGO

            return instantiatedSkill;
        }

        #endregion

        #region Animations

        [SerializeField, FoldoutGroup("References", -1)]
        private Animator animator;

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