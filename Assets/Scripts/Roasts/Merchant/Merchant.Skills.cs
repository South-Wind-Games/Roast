using System.Collections.Generic;
using System.Linq;
using Roasts.Input;
using Roasts.Skills.Data;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Roasts.Skills
{
    public partial class Merchant
    {
        [SerializeField] public SkillData[] SkillsList { get; private set; }

        [SerializeField] private RoastPlayer localPlayer = null;

#if UNITY_EDITOR
        [Button]
        private void LoadAllSkills()
        {
            SkillsList = Resources.LoadAll<SkillData>("SkillsData");
        }
#endif

        public SkillUI.UISkill[] GetAvailableSkills()
        {
            int UISkillsIndex = 0;
            SkillUI.UISkill[] UISkills = new SkillUI.UISkill[SkillsList.Length];
            // Ask player for his skills, convert them to UISKill, add them to the array.
            SkillData[] playerSkillsDatas = localPlayer.OwnedSkills.Keys.ToArray();


            // Upgrades
            foreach (var ownedSkill in localPlayer.OwnedSkills)
            {
                var ownedSkillKey = ownedSkill.Key;
                UISkills[UISkillsIndex++] = new SkillUI.UISkill(
                    ownedSkillKey.name,
                    ownedSkillKey.description,
                    Mathf.CeilToInt(ownedSkillKey.goldCost + ownedSkillKey.goldCost *
                        ownedSkillKey.goldIncreaseCurve.Evaluate((ownedSkill.Value - 1) * .1f)),
                    null,
                    ownedSkill.Value);
            }


            // Un owned skills
            var unOwnedSkills = SkillsList.Except(playerSkillsDatas);
            foreach (var unOwnedSkill in unOwnedSkills)
            {
                UISkills[UISkillsIndex++] = new SkillUI.UISkill(unOwnedSkill.name,
                    unOwnedSkill.description, unOwnedSkill.goldCost, null);
            }

            return UISkills;
        }

        public void OnPurchase(SkillData skill, RoastPlayer buyer)
        {
            if (buyer.Gold >= skill.goldCost)
            {
                buyer.GiveSkill(skill);
            }
            else
            {
                Debug.Log("Not enough gold");
            }
        }

        //[SerializeField,
        // DictionaryDrawerSettings(DisplayMode = DictionaryDisplayOptions.OneLine,
        // KeyLabel = "", ValueLabel = "")]
        //private Dictionary<SkillsNames, SkillData> skillsList = new Dictionary<SkillsNames, SkillData>();

        //public SkillData GetSkillData(SkillsNames whichSkillNames)
        //{
        //    return skillsList[whichSkillNames];
        //}
    }
}