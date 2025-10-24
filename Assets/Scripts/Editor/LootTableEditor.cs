using Game.Loot;
using UnityEditor;

namespace Editor
{
    [CustomEditor(typeof(LootTable))]
    public class LootTableEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var lootItems = serializedObject.FindProperty("_lootItems");
    
            int totalWeight = 0;
            for (int i = 0; i < lootItems.arraySize; i++)
            {
                var lootItem = lootItems.GetArrayElementAtIndex(i);

                int weight = lootItem.FindPropertyRelative("Weight").intValue;
                totalWeight += weight;
            }
            
            EditorGUILayout.LabelField($"Total weight: {totalWeight}");
        }
    }
}