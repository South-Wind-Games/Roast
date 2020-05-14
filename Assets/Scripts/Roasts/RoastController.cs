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
        private  IEnumerator rotatePerFrame;
        private Vector3 positionLook;

        private void Start()
        {
            rotatePerFrame = RotatePerFrame();
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

        public void LookAt()
        {
            Vector2 mousePoint = Mouse.current.position.ReadValue();
            Vector3 newMousePoint = new Vector3(mousePoint.x, 0, mousePoint.y);
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(newMousePoint);
            positionLook = new Vector3(worldPoint.x, transform.position.y, worldPoint.y);
            StartCoroutine(rotatePerFrame);
        }

        IEnumerator RotatePerFrame()
        {
            while (true)
            {
                Vector3 newDirection = Vector3.RotateTowards(
                    transform.forward,
                    positionLook,
                    Time.fixedDeltaTime * (rotationSpeed - 3f),
                    0.0f);
                transform.rotation = Quaternion.LookRotation(newDirection);
                yield return new WaitForEndOfFrame();
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
                StopCoroutine(rotatePerFrame);
                Transform roastTransform = transform;
                roastTransform.Translate(direction * (moveSpeed * Time.fixedDeltaTime), Space.World);
                Vector3 newDirection = Vector3.RotateTowards(
                    roastTransform.forward,
                    direction,
                    Time.fixedDeltaTime * rotationSpeed,
                    0.0f);

                roastTransform.rotation = Quaternion.LookRotation(newDirection);
            }
        }
    }
}