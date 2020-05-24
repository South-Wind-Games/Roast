using Roasts.Skills.Behaviour;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roasts.Skills.Data
{
    [CreateAssetMenu(fileName = "NewSkillData", menuName = "GameSettings/SkillData/Create new SkillData", order = 1)]
    public class SkillData : SerializedScriptableObject
    {
#if UNITY_EDITOR
        public bool ValidatePositive(float value)
        {
            return value > 0;
        }
#endif

        #region Skill stats

        [BoxGroup("Skill Configuration"), TitleGroup("Skill Configuration/Merchant Stats"), PropertyRange(1, 100),
         SuffixLabel("gold"), GUIColor(1, .9f, .1f)]
        public int goldCost = 1;

        [BoxGroup("Skill Configuration"), Multiline, TitleGroup("Skill Configuration/Merchant Stats")]
        public string description;

        [BoxGroup("Skill Configuration"), TitleGroup("Skill Configuration/Skill Basics"),
         ValidateInput(nameof(ValidatePositive), "Cooldown must be positive."),
         SuffixLabel("seconds", true)]
        public float coolDownTime = 1;

        [BoxGroup("Skill Configuration"), TitleGroup("Skill Configuration/Skill Basics"),
         SuffixLabel("absolute value", true)]
        public float significantAmount = 1;

        [BoxGroup("Skill Configuration"), TitleGroup("Skill Configuration/Skill Basics")]
        public AnimationCurve[] levelIncreaseCurves = {AnimationCurve.Linear(0, 1, 1, 10)};

        [BoxGroup("Skill Configuration"), TitleGroup("Skill Configuration/Animation")]
        public SkillStateMachine.SkillAnimationType animationType;

        #endregion

        #region Skill references

        [BoxGroup("References"), AssetList(Path = "Prefabs/Skills")]
        public SkillBase skillPrefab;

        [BoxGroup("References"), AssetList(Path = "Prefabs/Skills/FX")]
        public GameObject onCreateInstantiate, onDestroyInstantiate;

        #endregion
    }
}