using UnityEngine;

public class FlickerOnHealth : MonoBehaviour, Observer {
  [SerializeField] private HealthCounter healthCounter;
  [SerializeField] private NeonDriver neonDriver;

  public void Awake() {
    healthCounter.Register(this);
    neonDriver = GetComponent<NeonDriver>();
  }

  public void Notify() {
    float flickerIntensity = 1 - healthCounter.Health / healthCounter.MaxHealth;
    Debug.Log(flickerIntensity);
    neonDriver.Flicker(flickerIntensity);
  }
}
