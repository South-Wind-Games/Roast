using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillData : ScriptableObject
{
    public int goldCost;
    public float coolDownTime;
    public float significantAmount;
    public AnimationCurve[] levelIncreaseCurves;
}
