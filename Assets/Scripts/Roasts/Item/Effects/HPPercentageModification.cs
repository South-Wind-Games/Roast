using System.Collections;
using System.Collections.Generic;
using Roasts;
using UnityEngine;

namespace Roasts.Item.Effects
{
    public class HpPercentageModification : Effect
    {
        public override void ApplyEffect( )
        {
            stats.hpPercentageModifiaction += amount;
        }

        public override void DisableEffect( )
        {
            stats.hpPercentageModifiaction -= amount;
        }
    }
    
}
