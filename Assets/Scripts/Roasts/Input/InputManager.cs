using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Roasts.Input
{
    // TODO: It needs to require SkillsController
    [RequireComponent(typeof(RoastController))]
    [RequireComponent(typeof(RoastPlayer))]
    public class InputManager : MonoBehaviour
    {
        public enum InputMode
        {
            Default,
            Warlocks,
            Joystick
        }

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
            Extra_B4
        }

        [SerializeField, OnValueChanged(nameof(OnInputModeChanged))]
        private InputMode currentInputMode = InputMode.Default;

        private RoastsInput roastInput;

        [ShowInInspector, 
         DictionaryDrawerSettings(IsReadOnly = true, DisplayMode = DictionaryDisplayOptions.OneLine)]
        private Dictionary<Guid, UnityEvent> skills;

#if UNITY_EDITOR
        private void OnInputModeChanged()
        {
            //TODO: call UI functions here
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

        /*public void OnSchemeChanged(PlayerInput input)
        {
            Debug.Log(input.currentControlScheme);
        }*/

        private void Awake()
        {
            roastInput = new RoastsInput();
            skills = new Dictionary<Guid, UnityEvent>()
            {
                {roastInput.RoastMap.UsePrimarySkill.id, new UnityEvent()},
                {roastInput.RoastMap.UseSecondarySkill.id, new UnityEvent()},
            };
        }

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
                skills[context.action.id]?.Invoke();
            }
        }
    }
}