using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

// TODO: Add SkillData to the correct namespace.
[CreateAssetMenu(fileName = "NewSkillData", menuName = "GameSettings/SkillData/Create new SkillData", order = 1)]
public class SkillData : SerializedScriptableObject
{
    [PropertyRange(1, 100), InfoBox("This is the cost in gold coins for this skill at this level.")]
    public int goldCost = 1;
    public float coolDownTime;
    public float significantAmount;
    public AnimationCurve[] levelIncreaseCurves;
}