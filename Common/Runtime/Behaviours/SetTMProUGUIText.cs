using TMPro;
using UnityEngine;

namespace AFStudio.Common.Behaviours
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class SetTMProUGUIText : MonoBehaviour
    {
        private TextMeshProUGUI _textMeshProUGUI;

        private void Awake()
        {
            _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        }
        
        public void SetText(int value)
        {
            _textMeshProUGUI.text = value.ToString();
        }
    }
}