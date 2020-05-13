using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Roasts.Input
{
	// TODO: It needs to require SkillsController
    [RequireComponent(typeof(RoastController))]
    public class InputManager: MonoBehaviour
    {
        enum InputMode
        {
            Default,
            Warlocks,
            Joystick
        };

        private InputMode currentInputMode = InputMode.Default;

        #region Auto-Reference

        [SerializeField, HideInInspector] private RoastController roastController = null;

        private void OnValidate()
        {
            if (null == roastController)
            {
                roastController = GetComponent<RoastController>();
            }
        }

        #endregion

        public void OnMoveDirection(InputAction.CallbackContext context)
        {
            var rawInput = context.ReadValue<Vector2>();
            roastController.MoveInDirection(new Vector3(rawInput.x, 0, rawInput.y));
        }

        //Método para captar INPUT del mouse y rotar
        //(PABLITO)
        public void Confirmed(InputAction.CallbackContext context)
        {
            Vector2 look = context.ReadValue<Vector2>();
            roastController.StopAndLookAt(look);
            
        }

        
        //Método para captar el INPUT del mouse y trasladarme al punto seleccionado
        //(PABLITO)
        public void OnRightClicked(InputAction.CallbackContext context)
        {
            //Mouse.current.position.ReadValue()
            Vector2 clickInput = context.ReadValue<Vector2>();
            roastController.GetPointUnderCursor(clickInput);
           
        }

        
        
    

        public void OnRocketFire(InputAction.CallbackContext context)
        {
            Debug.Log("Rocket Selected");
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