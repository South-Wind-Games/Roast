using UnityEngine;
using UnityEngine.InputSystem;

namespace Roasts.Input
{
    enum InputMode
    {
        Default,
        Warlocks,
        Joystick
    };
    
    public class InputManager : MonoBehaviour
    {
        private InputMode currentInputMode = InputMode.Default;
        
        private Vector2 m_MoVe;
        
        

        public void OnMove (InputAction.CallbackContext context)
        {
            m_MoVe = context.ReadValue<Vector2>();
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


