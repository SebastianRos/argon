using System.Linq;
using UnityEditor;
using UnityEngine;

public class NeonController : MonoBehaviour, NeonDriver {
  private Color _color;
  public Color Color {
    get { return _color; }
    set {
      _color = value;
      foreach (NeonDriver neon in managedNeons) {
        neon.Color = _color;
      }
    }
  }

  private bool _isOn;
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
}

#if UNITY_EDITOR
[CustomEditor(typeof(NeonController))]

public class NeonControllerInspector : NeonDriverInspector {
  private NeonController neonController;

  public override void OnEnable() {
    base.OnEnable();
    neonController = (NeonController)target;
    neonController.UpdatedManagedNeons();
  }

  public override void OnInspectorGUI() {
    EditorGUILayout.BeginHorizontal();
    EditorGUILayout.LabelField("Managed neons: " + neonController.ManagedNeonCount);
    if (GUILayout.Button("update")) {
      neonController.UpdatedManagedNeons();
    }
    EditorGUILayout.EndHorizontal();
    base.OnInspectorGUI();
  }
}
#endif