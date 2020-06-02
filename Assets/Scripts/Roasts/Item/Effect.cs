using System;
using System.Collections;
using System.Collections.Generic;
using Roasts;
using Roasts.Input;
using UnityEditor.Compilation;
using UnityEngine;

namespace Roasts.Item
{
    [Serializable]
    public abstract class Effect
    {
        public float amount;
        public Stats stats;

        public abstract void ApplyEffect();

        public abstract void DisableEffect();
    }
}
