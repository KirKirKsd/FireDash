using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour {

	public static void SpawnEnemy(GameObject enemy) {
		Vector3 position = Vector3.zero;
		while (Vector2.Distance(position, Vector2.zero) < Variables.I3.x) {
			position = new Vector3(Random.Range(Variables.screen_width / 2 * -1, Variables.screen_width / 2), Random.Range(Variables.screen_width / 2 * -1, Variables.screen_width / 2), 0f);
		}
		Instantiate(enemy, position, Quaternion.Euler(0f, 0f, 0f));
	}
}
