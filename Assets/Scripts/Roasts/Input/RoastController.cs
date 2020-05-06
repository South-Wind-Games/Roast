using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Roasts.Input
{

    public class RoastController : MonoBehaviour
    {
        private float moveSpeed;
        private float moveRotation;

        private Vector2 m_MoveTowards;
        private Vector2 m_MoveToPosition;
        private Vector2 m_LookAt;

        public void MoveTowards(Vector2 context)
        {
            m_MoveTowards = context;
        }

        public void MoveToPosition()
        {
            
        }

        public void Stop()
        {
            moveSpeed = 0;
        }

        public void StopAndLookAt()
        {
            Stop();

            
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }    
}

