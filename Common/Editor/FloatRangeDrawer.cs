#if UNITY_EDITOR

using AFStudio.Common.Utils;
using UnityEditor;
using UnityEngine;

namespace AFStudio.Common.Editor
{
    [CustomPropertyDrawer(typeof(FloatRangeAttribute))]
    public class FloatRangeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Cast the attribute to access the range values.
            FloatRangeAttribute rangeAttribute = (FloatRangeAttribute)attribute;

            // Ensure the property is of float type.
            if (property.propertyType == SerializedPropertyType.Float)
            {
                EditorGUI.Slider(position, property, rangeAttribute.Min, rangeAttribute.Max, label);
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "Error: Use FloatRange with float.");
            }
        }
    }
}

#endif