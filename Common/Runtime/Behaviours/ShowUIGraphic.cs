using AFStudio.Common.Utils;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace AFStudio.Common.Behaviours
{
    public class ShowUIGraphic : MonoBehaviour
    {
        public Graphic Subject;
        
        [Header("CONFIG:")]
        public float FadeInTime = 0.5f;
        public float FadeOutTime = 0.5f;
        public Color Colour = Color.white;
        
        [Button]
        public void Show()
        {
            Subject.color = Colour;
            Subject.CrossFadeAlpha(Colour.a, FadeInTime, false);
        }
        
        [Button]
        public void Hide()
        {
            Subject.CrossFadeAlpha(0, FadeOutTime, false);
        }

        [Button]
        public void Flash()
        {
            Show();
            this.ScheduleAction(FadeInTime, Hide);
        }

        private void Awake()
        {
            Subject.color = Color.clear;
            Subject.CrossFadeAlpha(0, 0.01f, false);
        }

        private void Reset()
        {
            Subject = GetComponent<Graphic>();
        }
    }
}