using UnityEngine;

public class Gun : MonoBehaviour {
    public Transform hand;

    private void Update() {
        hand.rotation = Quaternion.Euler(0f, 0f, Player.gunAngle);
    }
}
