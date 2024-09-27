using UnityEngine;
using UnityEngine.UI;

namespace AFStudio.Common.Behaviours
{
    public class SetTextLabel : MonoBehaviour
    {
        public int DecimalPlaces = 2;

        public void SetText(float value)
        {
            Text text = GetComponent<Text>();
            if (text != null)
            {
                text.text = value.ToString("F" + DecimalPlaces);
            }
        }

        public void SetText(bool value)
        {
            Text text = GetComponent<Text>();
            if (text != null)
            {
                text.text = value.ToString();
            }
        }
    }
}
