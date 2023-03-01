using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 3f;

    private void Update() {
        transform.position = Vector2.MoveTowards(transform.position, Player.Pos, speed * Time.deltaTime);
    }
}
