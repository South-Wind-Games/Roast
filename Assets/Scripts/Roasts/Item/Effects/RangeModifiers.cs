using System.Collections;
using System.Collections.Generic;
using Roasts;
using UnityEngine;

namespace Roasts.Item.Effects
{
    public class RangeModifiers : Effect
    {
        public override void ApplyEffect( )
        {
            stats.rangeModifiers += amount;
        }

        public override void DisableEffect( )
        {
            stats.rangeModifiers += amount;
        }
    }
}
