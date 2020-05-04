using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Roasts
{
    [Serializable]
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(Mirror.NetworkTransform))]
    public class RoastController : Mirror.NetworkBehaviour
    {
        // TODO: Convert to auto-reference.
        public CharacterController characterController;

        [BoxGroup("Movement Settings"), SerializeField]
        private float moveSpeed = 10, turnSpeed = 10;

        [BoxGroup("Diagnostics"), ShowInInspector, ReadOnly]
        private Vector2 WASD;

        #region Input

        public void OnMove(InputAction.CallbackContext context)
        {
            WASD = context.ReadValue<Vector2>();
        }

        #endregion

        #region Auto-References

        void OnValidate()
        {
            if (characterController == null)
                characterController = GetComponent<CharacterController>();
        }

        #endregion

        private void FixedUpdate()
        {
            if (!isLocalPlayer)
                return;

            transform.Rotate(0f, WASD.x * turnSpeed * Time.fixedDeltaTime, 0f);
            //transform.Translate(Vector3.forward * (WASD.y * moveSpeed * Time.fixedDeltaTime));
        }
    }
}