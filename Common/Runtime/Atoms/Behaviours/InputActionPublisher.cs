using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AFStudio.Common.Atoms.Behaviours
{
    public class InputActionPublisher : MonoBehaviour
    {
        public InputActionReference InputAction;
        public VoidEvent OnInputAction;
        
        private void OnEnable()
        {
            InputAction.action.performed += OnInputActionPerformed;
        }
        
        private void OnDisable()
        {
            InputAction.action.performed -= OnInputActionPerformed;
        }
        
        private void OnInputActionPerformed(InputAction.CallbackContext context)
        {
            OnInputAction.Raise();
        }
    }
}