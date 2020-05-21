using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roasts.Skills.Behaviour
{
    
    public abstract class Skill<T> : SerializedMonoBehaviour where T : SkillData
    {
        [ShowInInspector, ReadOnly]
        protected RoastPlayer owner;

        [SerializeField, InlineEditor()]
        protected T data;

        [ShowInInspector]
        protected int currentLevel;


        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public abstract void Use();
    }
}