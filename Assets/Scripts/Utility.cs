using UnityEngine;

public class Utility : MonoBehaviour {
    public static float AngleTowardsMouse(Vector3 pos1, Vector3 pos2) {
        pos1 = Camera.main.WorldToScreenPoint(pos1);
        pos2 = Camera.main.WorldToScreenPoint(pos2);

        pos1.x = pos1.x - pos2.x;
        pos1.y = pos1.y - pos2.y;

        float angle = Mathf.Atan2(pos1.y, pos1.x) * Mathf.Rad2Deg + 180f;
        return angle;
    }
}
