using System.Collections.Generic;
using UnityEngine;

public class HealthCounter : MonoBehaviour, Damageable, Observable {
  [field: SerializeField] public float MaxHealth { get; private set; } = 10;
  [field: SerializeField] public float Health { get; private set; }

  public void Awake() {
    Health = MaxHealth;
  }

  private readonly List<Observer> observers = new();

  public void Damage(int damagePoints) {
    Health -= damagePoints;
    NotifyAllObservers();
  }

  public void Register(Observer observer) {
    observers.Add(observer);
  }
  public void Unregister(Observer observer) {
    observers.Remove(observer);
  }

  private void NotifyAllObservers() {
    foreach (Observer observer in observers) {
      observer.Notify();
    }
  }
}