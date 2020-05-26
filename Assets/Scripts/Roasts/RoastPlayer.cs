using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        public int Gold { get; private set; }   

        #region AutoReferences

        private void OnValidate()
        {
            if (null == animator)
                animator = GetComponent<Animator>();
        }

        #endregion

        #region IDamageable

        [SerializeField, BoxGroup("HP")] private HP hp = new HP();

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


        /// <summary>
        ///     Stores level for each owned skill.
        /// </summary>
        [SerializeField, BoxGroup("Skills"),
         DictionaryDrawerSettings(KeyLabel = "", ValueLabel = "",
             DisplayMode = DictionaryDisplayOptions.ExpandedFoldout)]
        private Dictionary<SkillSlots, SkillData> ownedSkills = new Dictionary<SkillSlots, SkillData>();
        private Dictionary<SkillData, int> skillLevels = new Dictionary<SkillData, int>();
        public Dictionary<SkillData, int> OwnedSkills => skillLevels;

        private void AddSkill(SkillSlots slot, SkillData skill, int level = 1)
        {
            ownedSkills[slot] = skill;
            skillLevels[skill] = level;
        }

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

            ownedSkills.Clear();
            skillLevels.Clear();
            AddSkill(SkillSlots.Primary,rocketData);
            AddSkill(SkillSlots.Secondary,selfC4);
        }
#endif
        //TODO: Create editor script
        public void GiveSkill(SkillData skillData)
        {
            if (ownedSkills.ContainsValue(skillData))
            {
                skillLevels[skillData]++;
            }
            else
            {
                AddSkill((SkillSlots) ownedSkills.Count, skillData);
            }
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