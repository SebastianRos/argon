using System;
using System.Collections;
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

  [SerializeField] private float minDuration;
  [SerializeField] private float maxDuration;
  [SerializeField] private float minOffTime;
  [SerializeField] private float maxOffTime;
  [SerializeField] private float lowerMinNextOff;
  [SerializeField] private float upperMinNextOff;
  [SerializeField] private float lowerMaxNextOff;
  [SerializeField] private float upperMaxNextOff;
  public void Flicker(float intensity) {
    StopAllCoroutines();
    StartCoroutine(FlickerCoroutine(intensity));
  }
  private IEnumerator FlickerCoroutine(float intensity) {
    float endTime = Time.time + Mathf.Lerp(minDuration, maxDuration, intensity);

    while (Time.time < endTime) {
      float offTime = UnityEngine.Random.Range(
        minOffTime,
        Mathf.Lerp(minOffTime, maxOffTime, intensity)
      );
      IsOn = false;
      yield return new WaitForSeconds(offTime);
      float nextOff = UnityEngine.Random.Range(
        Mathf.Lerp(upperMinNextOff, lowerMinNextOff, intensity),
        Mathf.Lerp(upperMaxNextOff, lowerMaxNextOff, intensity)
      );
      IsOn = true;
      yield return new WaitForSeconds(nextOff);
    }
    yield return null;
  }
}

#if UNITY_EDITOR
[CustomEditor(typeof(NeonElement))]
public class NeonElementInspector : NeonDriverInspector { }
#endif