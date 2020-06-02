using System.Collections;
using System.Collections.Generic;
using Roasts;
using UnityEngine;

namespace Roasts.Item.Effects
{
    public class DamageModifiers : Effect
    {
        public override void ApplyEffect( )
        {
            stats.damageModifers += amount;
        }
        public override void DisableEffect( )
        {
            stats.damageModifers -= amount;
        }
    }
}
