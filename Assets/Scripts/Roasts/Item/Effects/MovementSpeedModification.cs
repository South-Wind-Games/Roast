using System.Collections;
using System.Collections.Generic;
using Roasts;
using Roasts.Input;
using UnityEngine;

namespace Roasts.Item.Effects
{
    public class MovementSpeedModification : Effect
    {
        public override void ApplyEffect()
        {
            stats.movementSpeedModification += amount;
        }
        public override void DisableEffect( )
        {
            stats.movementSpeedModification -= amount;
        }
    }
}
