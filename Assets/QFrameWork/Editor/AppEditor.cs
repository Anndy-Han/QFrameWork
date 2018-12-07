using UnityEngine;
using UnityEditor;

namespace QFrameWork.Editor
{
    [CustomEditor(typeof(App))]
    [CanEditMultipleObjects]
    public class AppEditor: UnityEditor.Editor
    {
        App app;
        private void OnEnable()
        {
            app = target as App;
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.HelpBox(string.Format("{0}游戏引擎    -Version: {1}", app.appMate.AppName,app.appMate.EngineVersion), MessageType.Info);

            serializedObject.Update();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
