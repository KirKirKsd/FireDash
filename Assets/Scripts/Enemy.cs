using System.Collections;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public float speed = 1.5f;
	public float health = 50f;

	private bool needMove = true;

	private bool canShoot = true;
	private bool reloading = false;
	private bool playerStay = false;
	public float damage = 5f;

	private void Update() {
		if (needMove) {
			transform.position = Vector2.MoveTowards(transform.position, Player.Pos, speed * Time.deltaTime);
		}

		if (canShoot == false && reloading == false) {
			reloading = true;
			StartCoroutine(Reload());
		} 

		if (playerStay && canShoot) {
			Player.health -= damage;
			canShoot = false;
		}

		if (health <= 0) {
			Destroy(gameObject);
		}
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            needMove = false;
			playerStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            needMove = true;
			playerStay = false;
        }
    }

    IEnumerator Reload() {
		yield return new WaitForSeconds(1);
		canShoot = true;
		reloading = false;
	}
}
