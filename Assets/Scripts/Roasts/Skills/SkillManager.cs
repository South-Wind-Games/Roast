using System.Collections.Generic;
using Roasts.Skills.Data;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Roasts.Skills
{
    [CreateAssetMenu(fileName = "Skill Manager", menuName = "GameSettings/Skill Manager")]
    public class SkillManager : SerializedScriptableObject
    {
        /// <summary>
        ///     Enum that lists al existing skills.
        /// </summary>
        /// ************************************************************************************
        /// NOTE: Name must match EXACTLY the scriptable object's name without the "Data" part.
        /// Example:  SkillName.Teleport ==> TeleportData
        /// ************************************************************************************
        public enum SkillsNames
        {
            Rocket,
            SelfC4,
            Teleport,

            // ReSharper disable once InconsistentNaming
            SKILL_COUNT,
            INVALID
        }

        [SerializeField,
         DictionaryDrawerSettings(DisplayMode = DictionaryDisplayOptions.OneLine,
             KeyLabel = "", ValueLabel = "")]
        private Dictionary<SkillsNames, SkillData> skillsList = new Dictionary<SkillsNames, SkillData>();

#if UNITY_EDITOR
        [Button]
        private void LoadAllSkills()
        {
            skillsList.Clear();
            for (var i = 0; i < (int) SkillsNames.SKILL_COUNT; i++)
            {
                var currentSkill = (SkillsNames) i;
                var dataAssetName = currentSkill + "Data.asset";

                var skillData =
                    AssetDatabase.LoadAssetAtPath<SkillData>("Assets/GameSettings/SkillsData/" + dataAssetName);

                skillsList.Add((SkillsNames) i, skillData);
            }
        }
#endif

        public SkillData GetSkillData(SkillsNames whichSkillNames)
        {
            return skillsList[whichSkillNames];
        }
    }
}