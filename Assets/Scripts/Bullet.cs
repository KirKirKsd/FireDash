using UnityEngine;

public class Bullet : MonoBehaviour {
    public Rigidbody2D rb;
    public float speed = 10f;

    private void Update() {
        rb.velocity = transform.up * speed;
    }
}
