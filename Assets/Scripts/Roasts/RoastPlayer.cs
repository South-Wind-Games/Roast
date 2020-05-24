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
using static Roasts.Skills.SkillManager;

namespace Roasts
{
    public class RoastPlayer : SerializedMonoBehaviour, IDamageable
    {
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
        private struct OwnedSkill
        {
            public OwnedSkill(SkillsNames skillName, SkillData data, int level = 1)
            {
                this.skillName = skillName;
                this.data = data;
                this.level = level;
            }

            [ReadOnly]
            public SkillsNames skillName;

            [ProgressBar(0, 10, Segmented = true, DrawValueLabel = true), MinValue(1)]
            public int level;

            [ReadOnly]
            public SkillData data;
        }

        /// <summary>
        ///     Stores level for each owned skill.
        /// </summary>
        [SerializeField, BoxGroup("Skills"),
         DictionaryDrawerSettings(KeyLabel = "", ValueLabel = "",
             DisplayMode = DictionaryDisplayOptions.ExpandedFoldout)]
        private Dictionary<SkillSlots, OwnedSkill> ownedSkills = new Dictionary<SkillSlots, OwnedSkill>();

        [Button, FoldoutGroup("Skills/Set this player's skills")]
        private void SetDefaultSkills()
        {
            SkillData rocketData, selfC4;
            try
            {
                rocketData =
                    AssetDatabase.LoadAssetAtPath<SkillData>("Assets/GameSettings/SkillsData/RocketData.asset");
                selfC4 =
                    AssetDatabase.LoadAssetAtPath<SkillData>("Assets/GameSettings/SkillsData/SelfC4Data.asset");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            ownedSkills.Clear();
            ownedSkills.Add(SkillSlots.Primary, new OwnedSkill(SkillsNames.Rocket, rocketData));
            ownedSkills.Add(SkillSlots.Secondary, new OwnedSkill(SkillsNames.SelfC4, selfC4));
        }

        [Button(ButtonStyle.Box, Name = "Give this player a skill"),
         FoldoutGroup("Skills/Set this player's skills")]
        public void GiveSkill(SkillsNames skillName)
        {
            var dataAssetName = skillName + "Data.asset";

            var skillData =
                AssetDatabase.LoadAssetAtPath<SkillData>("Assets/GameSettings/SkillsData/" + dataAssetName);

            ownedSkills.Add((SkillSlots) ownedSkills.Count, new OwnedSkill(skillName, skillData));
        }

        /// <summary>
        ///     This gets called from InputManager to use the SkillName stored in that particular slot.
        ///     We then ask the skillManager to give use the prefab that corresponds with that SkillName."/>
        /// </summary>
        /// <param name="slot">Which skillSlot should be used.</param>
        public void UseSkill(SkillSlots slot)
        {
            StartCoroutine(RoastSkillAnimationRoutine(ownedSkills[slot].data));
        }

        private IEnumerator RoastSkillAnimationRoutine(SkillData skillData)
        {
            var skillPrefab = skillData.skillPrefab;

            if (skillData.animationType == SkillStateMachine.SkillAnimationType.None)
            {
                InstantiateSkill(skillData.skillPrefab);
            }
            else
            {
                if (skillData.animationType == SkillStateMachine.SkillAnimationType.PreAnimation ||
                    skillData.animationType == SkillStateMachine.SkillAnimationType.Both)
                {
                    animator.SetTrigger(PreAnimate);
                    animationDone = false;
                    yield return new WaitUntil(() => animationDone);

                    InstantiateSkill(skillData.skillPrefab);
                }

                if (skillData.animationType == SkillStateMachine.SkillAnimationType.PostAnimation ||
                    skillData.animationType == SkillStateMachine.SkillAnimationType.Both)
                {
                    animator.SetTrigger(PostAnimate);
                    if (skillData.animationType == SkillStateMachine.SkillAnimationType.PostAnimation)
                    {
                        animationDone = false;
                        yield return new WaitUntil(() => animationDone);
                        InstantiateSkill(skillData.skillPrefab);
                    }
                }
            }
        }


        private void InstantiateSkill(SkillBase skillPrefab)
        {
            Instantiate(skillPrefab); // TODO: Spawn correctly, not this shit.
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