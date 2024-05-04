using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class NeonElement : MonoBehaviour, NeonDriver {
  [field: SerializeField] private SpriteRenderer Core { get; set; }
  [field: SerializeField] private SpriteRenderer Glow { get; set; }

  [HideInInspector, SerializeField]
  private Color _color = Color.white;
  public Color Color {
    get { return _color; }
    set {
      _color = value;
      if (Glow && IsOn)
        Glow.color = _color;
    }
  }

  [HideInInspector, SerializeField]
  private bool _isOn = true;
  public bool IsOn {
    get { return _isOn; }
    set {
      _isOn = value;
      if (value)
        Glow.color = Color;
      else
        Glow.color = Color.clear;
    }
  }
}

#if UNITY_EDITOR
[CustomEditor(typeof(NeonElement))]
public class NeonElementInspector : NeonDriverInspector { }
#endif