using System;
using System.Collections.Generic;
using System.Linq;
using Roasts.Skills.Data;
using Roasts.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roasts.Merchant
{
    public partial class Merchant
    {
        [SerializeField]
        private SkillData[] skillsList;

        [SerializeField]
        private RoastPlayer localPlayer = null;

        private HashSet<SkillData> purchasedSkills = new HashSet<SkillData>();


#if UNITY_EDITOR
        [Button]
        private void LoadAllSkills()
        {
            skillsList = Resources.LoadAll<SkillData>("SkillsData");
        }
#endif

        public SkillUI.UISkill[] GetSkillUpgrades()
        {
            var playerOwnedSkills = localPlayer.OwnedSkills.Values;

            int i = 0;
            SkillUI.UISkill[] UISkills = new SkillUI.UISkill[playerOwnedSkills.Count];

            foreach (var ownedSkill in playerOwnedSkills)
            {
                var skillData = ownedSkill.data;
                UISkills[i++] = new SkillUI.UISkill(skillData.skillName,
                    skillData.description, skillData.goldCost, null,
                    ownedSkill.level + 1); // Tenias una tarea, mostrarlo.
            }

            return UISkills;
        }


        public SkillUI.UISkill[] GetUnOwnedSkills()
        {
            int UISkillsIndex = 0;

            var unOwnedSkills = skillsList.Except(purchasedSkills).ToArray();
            if (unOwnedSkills.Length > 0)
            {
                SkillUI.UISkill[] UISkills = new SkillUI.UISkill[unOwnedSkills.Length];

                foreach (var unOwnedSkill in unOwnedSkills)
                {
                    UISkills[UISkillsIndex++] = new SkillUI.UISkill(unOwnedSkill.skillName,
                        unOwnedSkill.description, unOwnedSkill.goldCost, null);
                }

                return UISkills;
            }

            throw new Exception("He owns EVERY SKILL?!?! This should never happen.");
        }

        [Button(ButtonStyle.Box)]
        public void OnPurchase(SkillData skillData, RoastPlayer buyer)
        {
            if (buyer.Gold >= skillData.goldCost)
            {
                buyer.GiveOrUpgradeSkill(skillData);
                purchasedSkills.Add(skillData);

                buyer.Gold -= skillData.goldCost;
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