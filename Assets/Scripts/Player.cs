using UnityEngine;

public class Player : MonoBehaviour {
    // movement
    public Joystick joystick;
    public float speed = 4f;

    // components
    public Rigidbody2D rb;

    private void Update() {
        Movement();
    }

    void Movement() {
        Vector2 movement = joystick.Direction;
        rb.velocity = movement * speed;
    }
}
