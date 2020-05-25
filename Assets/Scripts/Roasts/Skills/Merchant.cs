using Roasts.Skills.Data;
using UnityEngine;

namespace Roasts.Skills
{
    public class Merchant : MonoBehaviour
    {
        [SerializeField] 
        private ScriptableObject skillList;
        
        public void OnPurchase(SkillData skill, RoastPlayer buyer)
        {
            if (buyer.Gold >= skill.goldCost)
            {
                buyer.GiveSkill(skill);
            }
            else
            {
                print("Not enough gold");
            }
        }
    }
}
