using System;
using System.Collections.Generic;
using System.Linq;
using Roasts.Skills.Data;
using Sirenix.OdinInspector;
using UnityEngine;
using static Roasts.RoastPlayer;

namespace Roasts.Merchant
{
    public partial class Merchant
    {
        [SerializeField, ReadOnly]
        private SkillData[] skillsList;

        [SerializeField, ReadOnly]
        private RoastPlayer localPlayer = null;

        private HashSet<SkillData> purchasedSkills = new HashSet<SkillData>();

#if UNITY_EDITOR
        [Button]
        private void LoadAllSkills()
        {
            skillsList = Resources.LoadAll<SkillData>("SkillsData");
        }

        private void OnValidate()
        {
            InitializeMerchant();
        }
#endif

        private void InitializeMerchant()
        {
            if (null == localPlayer)
                localPlayer = FindObjectOfType<RoastPlayer>();
            if (null == skillsList)
                LoadAllSkills();
        }

        private void Awake()
        {
            InitializeMerchant();
        }

        public PlayerOwnedSkill[] GetSkillUpgrades()
        {
            return localPlayer.OwnedSkills;
        }

        public SkillData[] GetUnOwnedSkills()
        {
            return skillsList.Except(purchasedSkills).ToArray();
        }

        public void OnPurchaseSkill(SkillData newSkill)
        {
            if (localPlayer.Gold >= newSkill.goldCost)
            {
                localPlayer.PurchaseNewSkill(newSkill);
                purchasedSkills.Add(newSkill);

                localPlayer.Gold -= newSkill.goldCost;
            }
            else
            {
                Debug.Log("Not enough gold");
            }
        }

        public void OnUpgradeSkill(PlayerOwnedSkill ownedSkill)
        {
            localPlayer.UpgradeSkill(ownedSkill);
        }
    }
}