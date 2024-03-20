using MoreMountains.InventoryEngine;
using UnityEditor;

namespace Editor
{
    [CustomEditor(typeof(OuijaBoardSlotInventory))]
    public class OuijaBoardSlotInventoryEditor : InventorySlotEditor {
        protected SerializedProperty _cost;
        protected SerializedProperty _price;

        protected override void OnEnable() {
            base.OnEnable();

            _cost = serializedObject.FindProperty("cost");
            _price = serializedObject.FindProperty("price");
        }

        public override void OnInspectorGUI() {

            base.OnInspectorGUI();

            EditorGUILayout.LabelField("OuijaBoard", EditorStyles.boldLabel);
            EditorGUILayout.ObjectField(_cost);
            EditorGUILayout.ObjectField(_price);
        
            serializedObject.ApplyModifiedProperties();
        }
    }
}
