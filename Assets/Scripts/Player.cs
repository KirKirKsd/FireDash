using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	// movement
	public Joystick joystick;
	public float speed = 2f;

	// health
	public static float health = 100f;
	private float maxHealth;
	public Slider healthSlider;

	// gun
	public static float gunAngle;

    // transform
    public static Vector3 Pos;

	// light
	public new GameObject light;

	// bullet
	public GameObject bullet;
	private bool canShoot = true;
	private bool reloading = false;
	private GameObject nearEnemy = null;
	public Transform shootPoint;
	public static float damage = 25f;

	// components
	public Rigidbody2D rb;
	
	// score
	[SerializeField] public static int score = 0;
	public TextMeshProUGUI scoreText;

	private void Start() {
		transform.localScale = Variables.playerSize;
		light.transform.localScale = Vector3.one * (Variables.I2.x / Variables.playerSize.x);
		maxHealth = health;
	}

	private void Update() {
		Movement();
		SetSlidersValue();
		Pos = transform.position;
		GetGunAngle();
		Shoot();
		SetTexts();
	}

	void Movement() {
		Vector2 movement = joystick.Direction;
		rb.velocity = movement * speed;
	}

	void SetSlidersValue() {
		healthSlider.value = health / maxHealth;
	}

	GameObject GetNearestEnemy() {
        GameObject[] allEnemies = null;
        nearEnemy = null;
		float distance = 100001f;
		float nearestDistance = 10000f;

		allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

		for (int i = 0; i < allEnemies.Length; i++) {
			distance = Vector3.Distance(transform.position, allEnemies[i].transform.position);

			if (distance < nearestDistance && allEnemies[i].gameObject.GetComponent<Enemy>().visible) {
				nearEnemy = allEnemies[i];
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
		yield return new WaitForSeconds(0.5f);
		canShoot = true;
		reloading = false;
	}

	void SetTexts() {
		scoreText.text = score.ToString();
	}
}
