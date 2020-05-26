using Roasts.Skills;
using UnityEngine;

public class SkillUI
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

    Merchant merchant = null;

    public void DrawAvailableSkills()
    {
       UISkill[] skillsToDraw = merchant.GetAvailableSkills();
    }
}