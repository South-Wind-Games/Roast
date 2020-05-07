﻿using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Roasts.Input
{
	// TODO: It needs to require SkillsController
    [RequireComponent(typeof(RoastController))]
    public class InputManager : MonoBehaviour
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

        public void OnRightClicked(InputAction.CallbackContext context)
        {
        }

        public void OnRocketFire(InputAction.CallbackContext context)
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