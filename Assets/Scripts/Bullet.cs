using UnityEngine;

public class Bullet : MonoBehaviour {
    public Rigidbody2D rb;
    public float speed = 10f;
    public float damage = 5f;

    private void Start() {
        Destroy(gameObject, 2);
    }

    private void Update() {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<Enemy>().health -= damage;
        }
        Destroy(gameObject);
    }
}
