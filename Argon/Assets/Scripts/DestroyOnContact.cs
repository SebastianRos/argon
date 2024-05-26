using UnityEngine;

public class DestroyOnContact : MonoBehaviour {
  public void OnTriggerEnter2D() {
    Destroy(gameObject);
  }
}
