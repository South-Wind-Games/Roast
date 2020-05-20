using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Roasts.Input
{
    // TODO: It needs to require SkillsController
    [RequireComponent(typeof(RoastController))]
    public class InputManager : MonoBehaviour
    {
        public enum InputMode
        {
            Default,
            Warlocks,
            Joystick
        };

        [SerializeField, OnValueChanged(nameof(OnInputModeChanged))]
        private InputMode currentInputMode = InputMode.Default;
        
#if UNITY_EDITOR
        private void OnInputModeChanged()
        {
            //TODO: call UI functions here.
        }
#endif
        
        #region Auto-Reference

        [SerializeField, HideInInspector]
        private RoastController roastController = null;

        private void OnValidate()
        {
            if (null == roastController)
            {
                roastController = GetComponent<RoastController>();
            }
        }

        #endregion

        /*public void OnSchemeChanged(PlayerInput input)
        {
            Debug.Log(input.currentControlScheme);
        }*/

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

        public void OnSelfBomb(InputAction.CallbackContext context)
        {
        }

        public void OnSkill1(InputAction.CallbackContext context)
        {
        }

        public void OnSkill2(InputAction.CallbackContext context)
        {
        }

        public void OnSkill3(InputAction.CallbackContext context)
        {
        }

        public void OnSkill4(InputAction.CallbackContext context)
        {
        }

        public void OnSkill5(InputAction.CallbackContext context)
        {
        }
    }
}