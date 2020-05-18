using System.Collections;
using System.Collections.Generic;
using Roasts;
using UnityEditor.Compilation;
using UnityEngine;

public abstract class Effect
{
    private float amount;
    
    public abstract void ApplyEffect(RoastPlayer roastPlayer);
    
    public abstract void DisableEffect(RoastPlayer roastPlayer);
}
