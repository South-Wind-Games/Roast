using System;
using System.Collections;
using System.Collections.Generic;
using Roasts;
using Roasts.Input;
using UnityEditor.Compilation;
using UnityEngine;

namespace Roasts.Item
{
    public abstract class Effect
    {
        protected float amount;
    }
    
    public class CoolDownReduction : Effect
    {
        
    }
    
    public class DamageModifiers : Effect
    {
       
    }
    
    public class HpFlatModification : Effect
    {
        
    }
    
    public class HpPercentageModification : Effect
    {
       
    }
    
    public class MovementSpeedModification : Effect
    {
       
    }
    
    public class RangeModifiers : Effect
    {
        
    }
}
