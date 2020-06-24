using Roasts.Merchant;
using Roasts.Skills.Data;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;
using static Roasts.RoastPlayer;

namespace Editor
{
    [CustomEditor(typeof(Merchant))]
    public partial class MerchantEditor : OdinEditor
    {
        Merchant merchant = null;

        private SkillData[] unOwnedSkills = null;
        private PlayerOwnedSkill[] skillUpgrades = null;

        private string[] unOwnedSkillsNames = null, skillUpgradesNames = null;

        private int unOwnedSelected = -1, upgradeSelected = -1;

        private void Awake()
        {
            merchant = target as Merchant;
        }

        private void GetSkills()
        {
            unOwnedSkills = merchant.GetUnOwnedSkills();
            skillUpgrades = merchant.GetSkillUpgrades();

            UpdateSkillStrings();
        }


        private void UpdateSkillStrings()
        {
            if (null != merchant)
            {
                if (unOwnedSkills != null)
                {
                    unOwnedSkillsNames = new string[unOwnedSkills.Length];

                    for (int i = 0; i < unOwnedSkills.Length; i++)
                    {
                        var currentSkill = unOwnedSkills[i];
                        unOwnedSkillsNames[i] = $"{currentSkill.name} (g: {currentSkill.goldCost})";
                    }
                }


                if (skillUpgrades != null)
                {
                    skillUpgradesNames = new string[skillUpgrades.Length];

                    for (int i = 0; i < skillUpgrades.Length; i++)
                    {
                        var currentSkill = skillUpgrades[i];
                        skillUpgradesNames[i] =
                            $"{currentSkill.Data.name}(lvl:{currentSkill.Level} + 1) (g: {currentSkill.Data.goldCost})";
                    }
                }
            }
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (Application.isPlaying)
            {
                if (null == unOwnedSkills || null == skillUpgrades)
                    GetSkills();

                if (null != unOwnedSkills)
                {
                    EditorGUILayout.Separator();
                    EditorGUILayout.LabelField("New skill purchase: ");

                    unOwnedSelected = GUILayout.SelectionGrid(unOwnedSelected, unOwnedSkillsNames, 3);
                    if (unOwnedSelected != -1)
                    {
                        upgradeSelected = -1;

                        if (GUILayout.Button("Simulate skill purchase", GUILayout.Width(400)))
                        {
                            merchant.OnPurchaseSkill(unOwnedSkills[unOwnedSelected]);
                            GetSkills();
                            unOwnedSelected = -1;
                        }
                    }
                }

                if (null != skillUpgrades)
                {
                    EditorGUILayout.Separator();
                    EditorGUILayout.LabelField("Skill upgrade purchase: ");

                    upgradeSelected = GUILayout.SelectionGrid(upgradeSelected, skillUpgradesNames, 3);
                    if (upgradeSelected != -1)
                    {
                        unOwnedSelected = -1;

                        if (GUILayout.Button("Simulate skill upgrade", GUILayout.Width(400)))
                        {
                            merchant.OnUpgradeSkill(skillUpgrades[upgradeSelected]);
                            UpdateSkillStrings();
                            upgradeSelected = -1;
                        }
                    }
                }
            }
            else
            {
                EditorGUILayout.Separator();
                EditorGUILayout.LabelField("Start playing to enable the Skill Purchase/Upgrade inspector.");
            }
        }
    }
}