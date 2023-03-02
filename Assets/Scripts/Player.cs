using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	// movement
	public Joystick joystick;
	public float speed = 4f;

	// health
	public float health = 100f;
	private float max_health;
	public Slider healthSlider;

	// gun
	public Transform gun;
	public static float gunAngle;

    // transform
    public static Vector3 Pos;

	// bullet
	public GameObject bullet;
	private bool canShoot = true;
	private bool reloading = false;
	private GameObject nearEnemy = null;
	public Transform shootPoint;

	// components
	public Rigidbody2D rb;

	private void Start() {
		transform.localScale = Variables.playerSize;
		max_health = health;
	}

	private void Update() {
		Movement();
		SetSliderValue();
		Pos = transform.position;
		GetGunAngle();
		Shoot();
	}

	void Movement() {
		Vector2 movement = joystick.Direction;
		rb.velocity = movement * speed;
	}

	void SetSliderValue() {
		healthSlider.value = health / max_health;
	}

	GameObject GetNearestEnemy() {
        GameObject[] allEnimies = null;
        nearEnemy = null;
		float distance = 100001f;
		float nearestDistance = 10000f;

		allEnimies = GameObject.FindGameObjectsWithTag("Enemy");

		for (int i = 0; i < allEnimies.Length; i++) {
			distance = Vector3.Distance(transform.position, allEnimies[i].transform.position);

			if (distance < nearestDistance) {
				nearEnemy = allEnimies[i];
				nearestDistance = distance;
			}
		}

		return nearEnemy;
	}
	
	void GetGunAngle() {
		GameObject nearestEnemy = GetNearestEnemy();
		if (nearestEnemy != null) {
            gunAngle = Utility.AngleTowardsMouse(transform.position, nearestEnemy.transform.position);
        }
	}

	void Shoot() {
		if (canShoot && nearEnemy != null) {
			Instantiate(bullet, shootPoint.position, Quaternion.Euler(0f, 0f, gunAngle - 90f));
			canShoot = false;
		}
		else if (reloading == false) {
            reloading = true;
			StartCoroutine(Reload());
        }
	}

	IEnumerator Reload() {
		yield return new WaitForSeconds(1);
		canShoot = true;
		reloading = false;
	}
}
