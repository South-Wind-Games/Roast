using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : ScriptableObject
{
    public enum SlotType
    {
        Boots
    }
    public string name;
    public SlotType slot;
    public string description;
    public Item[] requeriments;
    public int price;
}
