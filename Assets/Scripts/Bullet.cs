using UnityEngine;

public class Bullet : MonoBehaviour {
    public Rigidbody2D rb;
    public float speed = 10f;
    private float damage;

    private void Start() {
        damage = Player.damage;
        Destroy(gameObject, 2);
    }

    private void Update() {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            collision.gameObject.GetComponent<Enemy>().health -= damage;
        }
        Destroy(gameObject);
    }
}
