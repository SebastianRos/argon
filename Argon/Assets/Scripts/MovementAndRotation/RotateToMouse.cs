using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RotateToMouse : MonoBehaviour
{
  private Rigidbody2D rb;

  void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate()
  {
    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector2 direction = mousePosition - transform.position;
    rb.MoveRotation(Quaternion.LookRotation(Vector3.forward, direction));
  }
}