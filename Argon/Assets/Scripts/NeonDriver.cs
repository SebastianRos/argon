using UnityEditor;
using UnityEngine;

public interface NeonDriver {
  public Color Color { get; set; }
  public bool IsOn { get; set; }
}


#if UNITY_EDITOR
public class NeonDriverInspector : Editor {
  private Color color = Color.white;
  private bool isOn = true;
  private NeonDriver neonElement;

  public virtual void OnEnable() {
    neonElement = (NeonDriver)target;
    color = neonElement.Color;
  }

  public override void OnInspectorGUI() {
    base.OnInspectorGUI();

    isOn = EditorGUILayout.Toggle("IsOn", isOn);
    neonElement.IsOn = isOn;
    color = EditorGUILayout.ColorField("Color", color);
    neonElement.Color = color;

  }
}
#endif