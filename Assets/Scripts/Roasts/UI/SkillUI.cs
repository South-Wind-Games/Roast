using Sirenix.OdinInspector;
using UnityEngine;

namespace Roasts.UI
{
    public class SkillUI : SerializedMonoBehaviour
    {
        public struct UISkill
        {
            public string name;
            public string description;
            public int level;
            public int goldCost;
            public Texture icon;

            public UISkill(string name, string description, int goldCost, Texture icon, int level = 1)
            {
                this.name = name;
                this.description = description;
                this.level = level;
                this.goldCost = goldCost;
                this.icon = icon;
            }
        }

        [SerializeField]
        Merchant.Merchant merchant = null;

        public void DrawAvailableSkills()
        {
            var upgrades = merchant.GetSkillUpgrades();

            var unOwnedSkills = merchant.GetUnOwnedSkills();

			// TODO: Draw UI
        }
    }
}