using System;
using Sirenix.OdinInspector;
using UnityEngine;
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

        [SerializeField] private InputActionAsset inputAsset;
        
        RoastsInput.RoastMapActions roastInput;

#if UNITY_EDITOR
        private void OnInputModeChanged()
        {
            //TODO: call UI functions here.
        }
#endif

        #region Auto-Reference

        [SerializeField, HideInInspector] private RoastController roastController = null;

        [SerializeField, HideInInspector] private RoastPlayer roastPlayer = null;

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

        private void Start()
        {
            //inputAsset.actionMaps
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
            Debug.Log(context.action);
            Debug.Log(context.action.id);
            Debug.Log(context.action.name);
            Debug.Log(context.action.type);

            /*if (/*context.action == roastInput.RoastMap.UsePrimarySkill)
            {
            }*/
        }

        public void OnPrimary(InputAction.CallbackContext context)
        {
        }

        public void OnSecondary(InputAction.CallbackContext context)
        {
        }

        public void OnQuickUseRight(InputAction.CallbackContext context)
        {
        }

        public void OnQuickUseLeft(InputAction.CallbackContext context)
        {
        }

        public void OnExtraA1(InputAction.CallbackContext context)
        {
        }

        public void OnExtraA2(InputAction.CallbackContext context)
        {
        }

        public void OnExtraA3(InputAction.CallbackContext context)
        {
        }

        public void OnExtraA4(InputAction.CallbackContext context)
        {
        }

        public void OnExtraB1(InputAction.CallbackContext context)
        {
        }

        public void OnExtraB2(InputAction.CallbackContext context)
        {
        }

        public void OnExtraB3(InputAction.CallbackContext context)
        {
        }

        public void OnExtraB4(InputAction.CallbackContext context)
        {
        }
    }
}