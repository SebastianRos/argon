using System.Collections.Generic;
using UnityEngine;

public class FireByPlayerInput : MonoBehaviour {
  [SerializeField] private GameObject[] fireableGos = new GameObject[1];
  private List<Fireable> fireables = new List<Fireable>();

  public void Awake() {
    foreach (GameObject firableGo in fireableGos) {
      if (firableGo != null) {
        Fireable fireable = firableGo.GetComponent<Fireable>();
        if (fireable != null) fireables.Add(fireable);
      }
    }
  }

  public void Update() {
    if (Input.GetMouseButtonDown(0)) {
      foreach (Fireable fireable in fireables) {
        fireable.Fire();
      }
    }
  }
}