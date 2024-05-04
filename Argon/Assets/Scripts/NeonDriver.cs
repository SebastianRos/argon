using UnityEditor;
using UnityEngine;

public interface NeonDriver {
  public Color Color { get; set; }
  public bool IsOn { get; set; }
}


#if UNITY_EDITOR
public class NeonDriverInspector : Editor {
  public override void OnInspectorGUI() {
    EditorGUILayout.PropertyField(serializedObject.FindProperty("_isOn"));
    EditorGUILayout.PropertyField(serializedObject.FindProperty("_color"));
    if (serializedObject.ApplyModifiedProperties()) {
      NeonDriver neonDriver = (NeonDriver)target;
      neonDriver.Color = neonDriver.Color;
      neonDriver.IsOn = neonDriver.IsOn;
    }
    base.OnInspectorGUI();
  }
}
#endif