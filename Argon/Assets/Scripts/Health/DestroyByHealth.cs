using UnityEngine;

public class DestroyByHealth : MonoBehaviour, Observer {
  [SerializeField] private HealthCounter healthCounter;

  public void Awake() {
    healthCounter.Register(this);
  }

  public void Notify() {
    float health = healthCounter.Health;
    if (health <= 0) {
      Destroy(gameObject);
    }
  }
}