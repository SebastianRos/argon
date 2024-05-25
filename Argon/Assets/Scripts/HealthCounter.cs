using System.Collections.Generic;
using UnityEngine;

public class HealthCounter : MonoBehaviour, Damageable, Observable {
  [field: SerializeField] public int Health { get; private set; } = 10;

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