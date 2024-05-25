using UnityEngine;

public class DestroyOnHealth : MonoBehaviour, Observer {
  [SerializeField] private HealthCounter healthCounter;

  public void Awake() {
    healthCounter.Register(this);
  }

  public void Notify() {
    int health = healthCounter.Health;
    if (health <= 0) {
      Destroy(gameObject);
    }
  }
}