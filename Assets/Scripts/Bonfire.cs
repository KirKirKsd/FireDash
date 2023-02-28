using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Bonfire : MonoBehaviour {
    private void Start() {
        transform.localScale = Vector3.one * Camera.main.ScreenToWorldPoint(new Vector2((Screen.width), 0)).x * 2 * 0.5f;
        print(Camera.main.ScreenToWorldPoint(new Vector2((Screen.width), 0)).x);
        print(Screen.width);
    }
}
