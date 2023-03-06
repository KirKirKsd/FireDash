using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;


public class Waves : MonoBehaviour {

    public static bool isWaveStarting = true;
    public static bool isWave = false;
    public bool canSpawn = true;
    public GameObject[] easyEnemies;
    public GameObject[] mediumEnemies;
    public GameObject[] hardEnemies;

    public int waveNum = 1;
    public GameObject[] enemies;
    public int amount = 0;
    public int left = 0;

    [SerializeField] public Slider waveSlider;
    public TextMeshProUGUI wavesCounterText;
    

    private void Start() {
        int item = Random.Range(0, easyEnemies.Length);
        enemies = Utility.AddToArray(enemies, easyEnemies[item]);
    }

    private void Update() {
        if (isWaveStarting) {
            BeforeWave();
        }

        if (isWave && canSpawn) {
            SpawnEnemy();
        }

        wavesCounterText.text = waveNum.ToString();
        waveSlider.value = left / amount;
    }

    void BeforeWave() {
        isWaveStarting = false;
        
        if (waveNum <= 10) {
            amount = waveNum * 2;
        }
        else {
            amount = 10 + waveNum;
        }

        left = amount;
        isWave = true;
    }

    void SpawnEnemy() {
        if (left > 0) {
            StartCoroutine(Cooldown());
        
            int item = Random.Range(0, enemies.Length - 1);
            SpawnEnemy(enemies[item]);

            left--;
        }
        else {
            AfterWave();
        }
    }

    IEnumerator Cooldown() {
        canSpawn = false;
        yield return new WaitForSeconds(5);
        canSpawn = true;
    }

    void AfterWave() {
        isWave = false;
        waveNum++;
        StartCoroutine(CooldownWaves());
    }

    IEnumerator CooldownWaves() {
        yield return new WaitForSeconds(10);
        isWaveStarting = true;
    }
    
    private Vector3 position;

    public void SpawnEnemy(GameObject enemy) {
        position = new Vector3(Random.Range(Variables.screen_width / 2 * -1, Variables.screen_width / 2), Random.Range(Variables.screen_width / 2 * -1, Variables.screen_width / 2), 0f);
        while (true) {
            if (Vector3.Distance(position, Vector3.zero) > Variables.I3.x) {
                position.y += UI.CenterPoint.y;
                break;
            }
            else { 
                position = new Vector3(Random.Range(Variables.screen_width / 2 * -1, Variables.screen_width / 2), Random.Range(Variables.screen_width / 2 * -1, Variables.screen_width / 2), 0f);
            } 
            Instantiate(enemy, position, Quaternion.Euler(0f, 0f, 0f));
        }
    }
    
}
