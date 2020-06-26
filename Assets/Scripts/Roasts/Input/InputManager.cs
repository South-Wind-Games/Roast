using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Roasts.Input
{
    // TODO: It needs to require SkillsController
    [RequireComponent(typeof(RoastController))]
    [RequireComponent(typeof(RoastPlayer))]
    public class InputManager : SerializedMonoBehaviour
    {
        public enum InputMode
        {
            Default,
            Warlocks,
            Joystick
        }


        [SerializeField, OnValueChanged(nameof(OnInputModeChanged))]
        private InputMode currentInputMode = InputMode.Default;

        #region Skills

        // For reference on the naming, see: https://love2d.org/w/images/d/d4/360_controller.png
        // enum JoystickMap
        // {
        //     RB,
        //     LB,
        //     RT,
        //     LT,
        //     A,
        //     B,
        //     X,
        //     Y,
        //     DPAD_UP,
        //     DPAD_DOWN,
        //     DPAD_LEFT,
        //     DPAD_RIGHT
        // }

        public enum SkillSlots
        {
            Primary,
            Secondary,
            QuickUseRight,
            QuickUseLeft,
            Extra_A1,
            Extra_A2,
            Extra_A3,
            Extra_A4,
            Extra_B1,
            Extra_B2,
            Extra_B3,
            Extra_B4,
            LENGTH
        }

        [SerializeField, ReadOnly,
         DictionaryDrawerSettings(IsReadOnly = true, DisplayMode = DictionaryDisplayOptions.OneLine)]
        private Dictionary<Guid, SkillSlots> skills = new Dictionary<Guid, SkillSlots>();

        [SerializeField,
         DictionaryDrawerSettings(DisplayMode = DictionaryDisplayOptions.OneLine, KeyLabel = "SkillSlot",
             ValueLabel = "InputActionReference"),
         ValidateInput(nameof(ValidateNewActions),
             "Actions need to be setup for ALL SkillSlots with a VALID InputActionReference.")]
        private Dictionary<SkillSlots, InputActionReference> actions =
            new Dictionary<SkillSlots, InputActionReference>
            {
                {SkillSlots.Primary, null},
                {SkillSlots.Secondary, null},
                {SkillSlots.QuickUseRight, null},
                {SkillSlots.QuickUseLeft, null},
                {SkillSlots.Extra_A1, null},
                {SkillSlots.Extra_A2, null},
                {SkillSlots.Extra_A3, null},
                {SkillSlots.Extra_A4, null},
                {SkillSlots.Extra_B1, null},
                {SkillSlots.Extra_B2, null},
                {SkillSlots.Extra_B3, null},
                {SkillSlots.Extra_B4, null},
            };

        public void RegisterSkill(SkillSlots slot)
        {
            skills[actions[slot].action.id] = slot;
        }

        public void CleanRegisteredSkills()
        {
            skills?.Clear();
        }

        #endregion


#if UNITY_EDITOR
        private void OnInputModeChanged()
        {
            //TODO: call UI functions here
        }

        [Button, ShowIf("@actions == null")]
        private void SetUpBareSlots()
        {
            actions =
                new Dictionary<SkillSlots, InputActionReference>
                {
                    {SkillSlots.Primary, null},
                    {SkillSlots.Secondary, null},
                    {SkillSlots.QuickUseRight, null},
                    {SkillSlots.QuickUseLeft, null},
                    {SkillSlots.Extra_A1, null},
                    {SkillSlots.Extra_A2, null},
                    {SkillSlots.Extra_A3, null},
                    {SkillSlots.Extra_A4, null},
                    {SkillSlots.Extra_B1, null},
                    {SkillSlots.Extra_B2, null},
                    {SkillSlots.Extra_B3, null},
                    {SkillSlots.Extra_B4, null},
                };
        }

        private bool ValidateNewActions(Dictionary<SkillSlots, InputActionReference> newActions)
        {
            if (null == newActions)
                return false;

            int validCount = 0;
            foreach (var newAction in newActions)
            {
                if (newAction.Value != null)
                    validCount++;
            }

            return validCount == newActions.Count && newActions.Count == (int) SkillSlots.LENGTH;
        }
#endif

        #region Auto-Reference

        [SerializeField, HideInInspector]
        private RoastController roastController = null;

        [SerializeField, HideInInspector]
        private RoastPlayer roastPlayer = null;

        private void OnValidate()
        {
            if (null == roastController)
            {
                roastController = GetComponent<RoastController>();
            }

            if (null == roastPlayer)
            {
                roastPlayer = GetComponent<RoastPlayer>();
            }
        }

        #endregion

        public void ChangeInputMode(InputMode newMode)
        {
            currentInputMode = newMode;
        }

        public void OnMoveDirection(InputAction.CallbackContext context)
        {
            if (currentInputMode == InputMode.Default)
            {
                var rawInput = context.ReadValue<Vector2>();
                roastController.MoveInDirection(new Vector3(rawInput.x, 0, rawInput.y));
            }
        }

        public void OnMouseMoveTo(InputAction.CallbackContext context)
        {
            if (context.performed && currentInputMode == InputMode.Warlocks)
                roastController.MoveTo(Mouse.current.position.ReadValue());
        }

        public void OnSelect(InputAction.CallbackContext context)
        {
        }

        public void OnSkillUse(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (skills.ContainsKey(context.action.id))
                    //TODO: Enviar direction al mouse normal
                    //TODO: Enviar magnitud de lo arriba ↑
                    //TODO: y enviar direccion en la que está mirando
                    roastPlayer.UseSkill(skills[context.action.id]);
                else
                    Debug.Log("Pressed a slot without a skill assigned.");
            }
        }
    }
}