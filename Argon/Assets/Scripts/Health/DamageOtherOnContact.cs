using UnityEngine;

public class DamageOtherOnContact : MonoBehaviour {
  [SerializeField] private int damage = 2;

  public void OnTriggerEnter2D(Collider2D collider) {
    Damageable damageable = collider.GetComponent<Damageable>();
    damageable?.Damage(damage);
  }
}
