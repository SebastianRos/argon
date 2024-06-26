using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class NeonController : MonoBehaviour, NeonDriver {
  [HideInInspector, SerializeField]
  private Color _color = Color.white;
  public Color Color {
    get { return _color; }
    set {
      _color = value;
      foreach (NeonDriver neon in managedNeons) {
        neon.Color = _color;
      }
    }
  }

  [HideInInspector, SerializeField]
  private bool _isOn = true;
  public bool IsOn {
    get { return _isOn; }
    set {
      _isOn = value;
      foreach (NeonDriver neon in managedNeons) {
        neon.IsOn = _isOn;
      }
    }
  }

  private NeonDriver[] managedNeons = new NeonDriver[0];
  public int ManagedNeonCount {
    get { return managedNeons.Length; }
  }

  public void UpdatedManagedNeons() {
    managedNeons = GetComponentsInChildren<NeonDriver>().Where(child => !child.Equals(this)).ToArray();
  }

  public void Awake() {
    UpdatedManagedNeons();
  }
  public void Start() {
    foreach (NeonDriver neonDriver in managedNeons) {
      neonDriver.Color = Color;
    }
  }

  public void Flicker(float intensity) {
    foreach (NeonDriver neonDriver in managedNeons) {
      neonDriver.Flicker(intensity);
    }
  }
}

#if UNITY_EDITOR
[CustomEditor(typeof(NeonController))]
public class NeonControllerInspector : NeonDriverInspector {
  public override void OnInspectorGUI() {
    base.OnInspectorGUI();

    NeonController neonController = (NeonController)target;

    EditorGUILayout.BeginHorizontal();
    EditorGUILayout.LabelField("Managed neons: " + neonController.ManagedNeonCount);
    if (GUILayout.Button("update")) {
      neonController.UpdatedManagedNeons();
    }
    EditorGUILayout.EndHorizontal();
  }
}
#endif