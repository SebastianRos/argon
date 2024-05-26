using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {
  [SerializeField] private float liveTime = 3;
  [SerializeField] private int damage = 2;
  public GameObject origin;

  public void Start() {
    StartCoroutine(DestroyAfterLiveTime());
  }

  private IEnumerator DestroyAfterLiveTime() {
    yield return new WaitForSeconds(liveTime);
    Destroy(gameObject);
  }

  public void OnTriggerEnter2D(Collider2D collider) {
    if (collider.gameObject == origin) return;

    Damageable damageable = collider.GetComponent<Damageable>();
    damageable?.Damage(damage);
    Destroy(gameObject);
  }
}
