using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class HierarchySeparatorUtils
    {
        private const string SeparatorDefaultName = "==== SEPARATOR ====";
        
        [MenuItem("GameObject/Add Hierarchy Separator")]
        public static void AddHierarchySeparator()
        {
            var separator = new GameObject(SeparatorDefaultName)
            {
                tag = "EditorOnly"
            };

            Undo.RegisterCreatedObjectUndo(separator, $"Create {SeparatorDefaultName}");
            Selection.activeObject = separator;
        }
    }
}
