using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveByPlayerInput : MonoBehaviour {
    public float speed = 1;

    private Rigidbody2D rb;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        Vector2 newVelocity = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) {
            newVelocity += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A)) {
            newVelocity += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S)) {
            newVelocity += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D)) {
            newVelocity += Vector2.right;
        }
        rb.velocity = newVelocity * speed;
    }
}
