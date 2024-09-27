using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace AFStudio.Common.Behaviours
{
    public class InputActionBtnToEvent : MonoBehaviour
    {
        public InputActionReference InputAction;
        public UnityEvent OnBtnPressed;

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
            Debug.Log("Input action performed");
            Invoke();
        }

        [Button]
        private void Invoke()
        {
            OnBtnPressed?.Invoke();
        }
    }
}
