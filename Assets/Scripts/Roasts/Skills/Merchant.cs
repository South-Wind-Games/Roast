using System.Collections.Generic;
using Roasts.Skills.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Roasts.Skills
{
    public class Merchant : MonoBehaviour
    {
        [SerializeField] 
        private SkillManager skillManager;

        
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
