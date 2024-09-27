#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AFStudio.Common.Utils;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace AFStudio.Common.Editor
{
	public class TagStringDrawer : OdinAttributeDrawer<TagAttribute, string>
	{
		private readonly GUIContent _mButtonContent = new GUIContent();

		protected override void Initialize() => UpdateButtonContent();

		private void UpdateButtonContent()
		{
			_mButtonContent.text = ValueEntry.SmartValue;
		}

		protected override void DrawPropertyLayout(GUIContent label)
		{
			var rect = EditorGUILayout.GetControlRect(label != null);

			rect = label == null ? EditorGUI.IndentedRect(rect) : EditorGUI.PrefixLabel(rect, label);

			if (!EditorGUI.DropdownButton(rect, _mButtonContent, FocusType.Passive)) return;

			var selector = new GenericSelector<string>(UnityEditorInternal.InternalEditorUtility.tags);
			selector.SetSelection(ValueEntry.SmartValue);
			selector.ShowInPopup(rect.position);

			selector.SelectionChanged += x =>
			{
				ValueEntry.Property.Tree.DelayAction(() =>
				{
					ValueEntry.SmartValue = x.FirstOrDefault();

					UpdateButtonContent();
				});
			};
		}
	}

	public abstract class TagStringListBaseDrawer<T> : OdinAttributeDrawer<TagAttribute, T> where T : IList<string>
	{
		private readonly GUIContent _mButtonContent = new GUIContent();

		protected override void Initialize() => UpdateButtonContent();

		private void UpdateButtonContent()
		{
			_mButtonContent.text = _mButtonContent.tooltip = string.Join(", ", ValueEntry.SmartValue);
		}

		protected override void DrawPropertyLayout(GUIContent label)
		{
			var rect = EditorGUILayout.GetControlRect(label != null);

			rect = label == null ? EditorGUI.IndentedRect(rect) : EditorGUI.PrefixLabel(rect, label);

			if (!EditorGUI.DropdownButton(rect, _mButtonContent, FocusType.Passive)) return;

			var selector = new TagSelector(UnityEditorInternal.InternalEditorUtility.tags);

			rect.y += rect.height;

			selector.SetSelection(ValueEntry.SmartValue);
			selector.ShowInPopup(rect.position);

			selector.SelectionChanged += x =>
			{
				ValueEntry.Property.Tree.DelayAction(() =>
				{
					UpdateValue(x);
					UpdateButtonContent();
				});
			};
		}

		protected abstract void UpdateValue(IEnumerable<string> x);
	}

	[DrawerPriority(1)]
	[DontApplyToListElements]
	public class TagStringArrayDrawer : TagStringListBaseDrawer<string[]>
	{
		protected override void UpdateValue(IEnumerable<string> x) => ValueEntry.SmartValue = x.ToArray();
	}

	[DrawerPriority(1)]
	[DontApplyToListElements]
	public class TagStringListDrawer : TagStringListBaseDrawer<List<string>>
	{
		protected override void UpdateValue(IEnumerable<string> x) => ValueEntry.SmartValue = x.ToList();
	}

	public class TagSelector : GenericSelector<string>
	{
		private readonly FieldInfo _mRequestCheckboxUpdate;

		public TagSelector(string[] tags) : base(tags)
		{
			CheckboxToggle = true;

			_mRequestCheckboxUpdate = typeof(GenericSelector<string>).GetField("requestCheckboxUpdate",
				BindingFlags.NonPublic | BindingFlags.Instance);
		}

		protected override void DrawSelectionTree()
		{
			base.DrawSelectionTree();

			EditorGUILayout.BeginHorizontal();

			if (GUILayout.Button("None"))
			{
				SetSelection(new List<string>());

				_mRequestCheckboxUpdate.SetValue(this, true);
				TriggerSelectionChanged();
			}

			if (GUILayout.Button("All"))
			{
				SetSelection(UnityEditorInternal.InternalEditorUtility.tags);

				_mRequestCheckboxUpdate.SetValue(this, true);
				TriggerSelectionChanged();
			}

			EditorGUILayout.EndHorizontal();
		}
	}
}

#endif