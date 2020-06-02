using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roasts.Item
{
    [CreateAssetMenu(fileName = "New Item")]
    public class Item : SerializedScriptableObject
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
        public Effect[] effects;
    }
   
}
