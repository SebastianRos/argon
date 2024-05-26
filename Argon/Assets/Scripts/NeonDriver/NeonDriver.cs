using UnityEditor;
using UnityEngine;

public interface NeonDriver {
  public Color Color { get; set; }
  public bool IsOn { get; set; }

  public void Flicker(float intensity);
}


#if UNITY_EDITOR
public class NeonDriverInspector : Editor {
  private float flickerIntensity = 1;

  public override void OnInspectorGUI() {
    NeonDriver neonDriver = (NeonDriver)target;
    EditorGUILayout.PropertyField(serializedObject.FindProperty("_isOn"));
    EditorGUILayout.PropertyField(serializedObject.FindProperty("_color"));
    if (serializedObject.ApplyModifiedProperties()) {
      neonDriver.Color = neonDriver.Color;
      neonDriver.IsOn = neonDriver.IsOn;
    }
    EditorGUILayout.BeginHorizontal();
    bool flicker = GUILayout.Button("Flicker");
    EditorGUILayout.Space();
    flickerIntensity = EditorGUILayout.FloatField("Intensity", flickerIntensity);
    if (flicker) neonDriver.Flicker(flickerIntensity);
    EditorGUILayout.EndHorizontal();
    base.OnInspectorGUI();
  }
}
#endif