using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    [CustomEditor(typeof(TileMap))]
    public class TileMapInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Regenerate"))
            {
                var targetMap = (TileMap) target;
                targetMap.BuildMesh();
            }
        }
    }
}
