using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace Roasts
{
    [Serializable]
#if ROAST_NETWORKING_ENABLED
    [RequireComponent(typeof(Mirror.NetworkTransform))]
#endif
    public class RoastController
#if ROAST_NETWORKING_ENABLED
        : Mirror.NetworkBehaviour
#else
        : MonoBehaviour
#endif
    {
        [TabGroup("Movement Settings"), SerializeField]
        private float moveSpeed = 10, rotationSpeed = 1;

        [TabGroup("Diagnostics"), ShowInInspector, ReadOnly]
        private Vector3 direction;

        private Vector3 mouseDirection, mousePosition;

        private IEnumerator rotatePerFrame;

        public Camera camera;


        private void Awake()
        {
            rotatePerFrame = RotatePerFrame();
            camera = Camera.main;
        }

        public void MoveInDirection(Vector3 inputDirection)
        {
            direction = inputDirection;
        }
        
        public void MoveToPosition(Vector2 mousePosition)
        {
        }

        public void Stop()
        {
            moveSpeed = 0;
        }

        public void LookAt(Vector3 inputDirection)
        {
            // // Vector2 mousePoint = Mouse.current.position.ReadValue();
            //
            // Vector3 newMousePoint = new Vector3(mousePoint.x, 0, mousePoint.y);
            mouseDirection = inputDirection;
            
            Vector3 worldPoint = camera.ScreenToWorldPoint(mouseDirection);

            mousePosition = new Vector3(worldPoint.x, transform.position.y, worldPoint.y);

            StartCoroutine(rotatePerFrame);

        }

         IEnumerator RotatePerFrame()
         {
            while (true)
            {
                Vector3 newDirection = Vector3.RotateTowards(
                    transform.forward,
                    mousePosition,
                    Time.fixedDeltaTime * rotationSpeed,
                    0.0f);
            
                transform.rotation = Quaternion.LookRotation(newDirection);
            
                yield return null;
            }
        }
        

        private void FixedUpdate()
        {
#if ROAST_NETWORKING_ENABLED
            if (!isLocalPlayer)
                return;
#endif
            if (direction.sqrMagnitude > 0)
            {
                Transform roastTransform = transform;

                roastTransform.Translate(direction * (moveSpeed * Time.fixedDeltaTime), Space.World);

                Vector3 newDirection = Vector3.RotateTowards(
                    roastTransform.forward,
                    direction,
                    Time.fixedDeltaTime * rotationSpeed,
                    0.0f);

                roastTransform.rotation = Quaternion.LookRotation(newDirection);

                StopCoroutine(rotatePerFrame);

            }
            
            
        }
    }
}