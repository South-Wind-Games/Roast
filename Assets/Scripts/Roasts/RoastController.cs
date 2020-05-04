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
        private float moveSpeed = 10;

        [BoxGroup("Diagnostics"), ShowInInspector, ReadOnly]
        private Vector3 WASD;

        #region Input

        public void OnMove(InputAction.CallbackContext context)
        {
            var input = context.ReadValue<Vector2>();

            WASD = new Vector3(input.x, 0, input.y);
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

            transform.Translate(WASD * (moveSpeed * Time.fixedDeltaTime));
        }
    }
}