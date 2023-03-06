using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour {
	private Vector3 position;
    private bool canSpawn = true;
    public GameObject enemy;

    private void Update() {
        if (canSpawn) {
            canSpawn = false;
            position = new Vector3(Random.Range(Variables.screen_width / 2 * -1, Variables.screen_width / 2), Random.Range(Variables.screen_width / 2 * -1, Variables.screen_width / 2), 0f);
            while (true) {
                if (Vector3.Distance(position, Vector3.zero) > Variables.I3.x) {
                    position.y += UI.CenterPoint.y;
                    break;
                }
                else {
                    position = new Vector3(Random.Range(Variables.screen_width / 2 * -1, Variables.screen_width / 2), Random.Range(Variables.screen_width / 2 * -1, Variables.screen_width / 2), 0f);
                }
            }
            Instantiate(enemy, position, Quaternion.Euler(0f, 0f, 0f));
            StartCoroutine(Timings());
        }
    }

    IEnumerator Timings() {
        yield return new WaitForSeconds(2);
        canSpawn = true;
    }
}
