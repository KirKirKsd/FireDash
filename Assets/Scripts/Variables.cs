using UnityEngine;

public class Variables : MonoBehaviour {
    // screen size
    public static float screen_width = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0f)).x * 2;
    public static float screen_height = Camera.main.ScreenToWorldPoint(new Vector2(Screen.height, 0f)).x * 2;

    // basic sizes
    public static Vector3 I3 = Vector3.one * screen_width / 2;
    public static Vector3 I2 = Vector3.one * screen_width / 3;
    public static Vector3 I1 = Vector3.one * screen_width / 4;

    // player
    public static Vector3 playerSize = Vector3.one * screen_width / 24;
}
