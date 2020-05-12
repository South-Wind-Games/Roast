using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roasts
{
    [Serializable]
    [RequireComponent(typeof(Mirror.NetworkTransform))]
    public class RoastController : Mirror.NetworkBehaviour
    {
       
        [TabGroup("Movement Settings"), SerializeField]
        private float moveSpeed = 10, rotationSpeed = 1;

        [TabGroup("Diagnostics"), ShowInInspector, ReadOnly]
        private Vector3 direction;

     
        public void MoveInDirection(Vector3 inputDirection)
        {
            direction = inputDirection;


        }

        public void MoveToPosition(Vector2 mousePosition)
        {
        }

        public void Stop()
        {
        }

        public void StopAndLookAt()
        {
            Stop();
        }

        /*private void Update()
        {
            
        }*/

        private void FixedUpdate()
        {
            if (!isLocalPlayer)
                return;
            


            // transform.Translate(direction * (moveSpeed * Time.fixedDeltaTime), 
                // Space.World);
            // TODO: Player needs to rotate to face the direction he's moving.
        }
    }
}