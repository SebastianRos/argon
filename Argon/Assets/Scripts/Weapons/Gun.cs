using UnityEngine;

public class Gun : MonoBehaviour, Fireable {
  [SerializeField] private GameObject bulletPrefab;
  [SerializeField] private Transform shotSpawn;
  [SerializeField] private float bulletSpeed = 30;

  private AudioSource audioSource;

  public void Awake() {
    audioSource = GetComponent<AudioSource>();
  }

  public void Fire() {
    GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
    Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
    if (bulletRb) {
      Vector2 direction = transform.rotation * Vector2.up * bulletSpeed;
      bulletRb.velocity = direction;
    }

    if (audioSource) audioSource.PlayOneShot(audioSource.clip);
  }
}
