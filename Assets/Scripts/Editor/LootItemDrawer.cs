using UnityEditor;
using Game;
using Game.Loot;
using UnityEngine;

namespace Editor
{
    [CustomPropertyDrawer(typeof(LootItem))]
    public class LootItemDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var prefabRect = new Rect(position.x, position.y, position.width * 0.8f, position.height);
            var weightRect = new Rect(prefabRect.xMax + 5, position.y, position.width * 0.2f - 5, position.height);

            EditorGUI.PropertyField(prefabRect, property.FindPropertyRelative("Prefab"), GUIContent.none);
            EditorGUI.PropertyField(weightRect, property.FindPropertyRelative("Weight"), GUIContent.none);

            EditorGUI.EndProperty();
        }
    }
}