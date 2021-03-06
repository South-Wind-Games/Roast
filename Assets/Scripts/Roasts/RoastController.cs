using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

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
        // TODO: Use Odin to show rotationSpeed in Degrees/Second
        [TabGroup("Movement Settings"), SerializeField]
        private float moveSpeed = 10, rotationSpeed = 1;

        [TabGroup("Movement Settings"), SerializeField]
        private Camera roastCamera = null;

        [TabGroup("Diagnostics"), ShowInInspector, ReadOnly]
        private Vector3 direction;

        private Coroutine rotateRoutine, moveRoutine = null;

        public void MoveInDirection(Vector3 inputDirection)
        {
            direction = inputDirection;
        }

        public void Stop()
        {
            StopCoroutine(moveRoutine);

            StopCoroutine(rotateRoutine);
        }

        private Vector3 ScreenCoordinateToWorldPosition(Vector2 coordinates)
        {
            var cameraToEyeHeight = roastCamera.transform.position.y - transform.position.y;

            var mouseCoordsNoY =
                new Vector3(
                    coordinates.x,
                    coordinates.y,
                    cameraToEyeHeight);

            return roastCamera.ScreenToWorldPoint(mouseCoordsNoY);
        }

        public void LookAt(Vector2 mouseCoordinates)
        {
            // Debug.Log($"screen to world position: {worldPointYFixed}");
            if (null != rotateRoutine)
                StopCoroutine(rotateRoutine);

            rotateRoutine = StartCoroutine(
                LookAtRoutine(
                    ScreenCoordinateToWorldPosition(mouseCoordinates)));
        }

        public void MoveTo(Vector2 mouseCoordinates)
        {
            if (null != moveRoutine)
                StopCoroutine(moveRoutine);

            var worldPos = ScreenCoordinateToWorldPosition(mouseCoordinates);

            moveRoutine = StartCoroutine(MoveToRoutine(worldPos));

            rotateRoutine = StartCoroutine(LookAtRoutine(worldPos));
        }

        IEnumerator MoveToRoutine(Vector3 moveAtPosition)
        {
            Transform roastTransform = transform;

            var toVector = moveAtPosition - roastTransform.position;

            //Esta variable calcula la dirección del vector resultante
            var oldSchoolDirection = toVector.normalized;

            while ((moveAtPosition - roastTransform.position).sqrMagnitude > .01f)
            {
                roastTransform.Translate(
                    oldSchoolDirection * (moveSpeed * Time.fixedDeltaTime), Space.World);

                yield return new WaitForFixedUpdate();
            }

            roastTransform.position = moveAtPosition;
        }

        IEnumerator LookAtRoutine(Vector3 lookAtPosition)
        {
            var roastTransform = transform;

            var toClickDirection = (lookAtPosition - roastTransform.position).normalized;

            // Angulo en radianes entre los vectores
            float alpha = Mathf.Acos(Vector3.Dot(toClickDirection, roastTransform.forward));

            // Cuanto voy a rotar este frame
            float frameRotationDelta;

            // Pa ke lao
            bool sign = roastTransform.InverseTransformPoint(lookAtPosition).x > 0;

            do
            {
                // Cuanto roto este frame
                frameRotationDelta = rotationSpeed * Time.fixedDeltaTime;

                // No me paso de vueltas?
                if (alpha >= frameRotationDelta)
                    transform.Rotate(sign ? Vector3.up : Vector3.down, frameRotationDelta * Mathf.Rad2Deg);

                yield return null;
                // a = cos-1 ( A dot B )
                alpha = Mathf.Acos(Vector3.Dot(toClickDirection, roastTransform.forward));
            } while (alpha >= frameRotationDelta);

            // Terminar de rotar lo que falta para estar exactamente con el mouse
            transform.forward = toClickDirection;
            rotateRoutine = null;
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

                roastTransform.Translate(direction * (moveSpeed * Time.fixedDeltaTime), 
                    Space.World);

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