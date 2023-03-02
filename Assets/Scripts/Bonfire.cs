using UnityEngine;
using UnityEngine.UI;

public class Bonfire : MonoBehaviour {
	// health
	public float health = 250f;
	private float max_health;
	public Slider healthSlider;

	// gameobjects
	public new GameObject light;

	private void Start() {
		max_health = health;
		light.transform.localScale = Variables.I3;
	}

	private void Update() {
		Vector3 scale = Vector3.one * (health / max_health * (Variables.I3.x - Variables.I2.x) + Variables.I2.x);
		light.transform.localScale = scale;
		SetSliderValue();
	}

    void SetSliderValue() {
        healthSlider.value = health / max_health;
    }
}
