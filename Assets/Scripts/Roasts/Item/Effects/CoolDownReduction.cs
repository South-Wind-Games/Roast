using System.Collections;
using System.Collections.Generic;
using Roasts;
using UnityEngine;

namespace Roasts.Item.Effects
{
    
    public class CoolDownReduction : Effect
    {
        public override void ApplyEffect()
        {
            stats.coolDownPercentageReduction += amount;
        }

        public override void DisableEffect()
        {
            stats.coolDownPercentageReduction -= amount;
        }
    }
}
