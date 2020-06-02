using System.Collections;
using System.Collections.Generic;
using Roasts;
using UnityEngine;

namespace Roasts.Item.Effects
{
    public class HpFlatModification : Effect
    {
        public override void ApplyEffect( )
        {
            stats.hpFlatModification += amount;
        }

        public override void DisableEffect( )
        {
            stats.hpFlatModification += amount;
        }
    }

}