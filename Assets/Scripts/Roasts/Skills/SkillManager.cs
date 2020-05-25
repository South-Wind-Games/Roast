using System.Collections.Generic;
using Roasts.Skills.Behaviour;
using Roasts.Skills.Data;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Serialization;

namespace Roasts.Skills
{
    [CreateAssetMenu(fileName = "Skill Manager", menuName = "GameSettings/Skill Manager")]
    public class SkillManager : SerializedScriptableObject
    {
        //[SerializeField,
        // DictionaryDrawerSettings(DisplayMode = DictionaryDisplayOptions.OneLine,
        // KeyLabel = "", ValueLabel = "")]
        //private Dictionary<SkillsNames, SkillData> skillsList = new Dictionary<SkillsNames, SkillData>();
        [SerializeField]
        public SkillData[] SkillsList { get; private set; }
#if UNITY_EDITOR
        
        [Button]
        
        private void LoadAllSkills()
        {
            SkillsList = Resources.LoadAll<SkillData>("SkillsData");
        }
        
#endif

       //public SkillData GetSkillData(SkillsNames whichSkillNames)
       //{
       //    return skillsList[whichSkillNames];
       //}
    }
}