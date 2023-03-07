using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Waves : MonoBehaviour {

    public List<GameObject> easyEnemies;
    public List<GameObject> mediumEnemies;
    public List<GameObject> hardEnemies;

    private List<GameObject> enemies = new();

    public int count;
    public int left;
    public int waveNum = 2;

    public Slider waveProgressSlider;
    public TextMeshProUGUI wavesCounterText;

    private void Start() {
        AddToEnemies("easy");
        StartCoroutine(Wave());
    }

    private void Update() {
        SetUI();
    }

    void SetUI() {
        float cof = (float) left / count;
        waveProgressSlider.value = 1 - cof;
        wavesCounterText.text = waveNum.ToString();
    }
    
    private IEnumerator Wave() {
        // before
        switch (waveNum) {
            case <= 10:
                count = waveNum * 2;
                break;
            case > 10:
                count = waveNum + 10;
                break;
        }

        left = count;
        
        // during
        while (left > 0) {
            Spawner.SpawnEnemy(enemies[Random.Range(0, enemies.Count)]);
            left--;
            yield return new WaitForSeconds(2);
        }
        
        // after
        int enemiesNow = GameObject.FindGameObjectsWithTag("Enemy").Length;
        while (enemiesNow != 0) {
            enemiesNow = GameObject.FindGameObjectsWithTag("Enemy").Length;
            yield return new WaitForSeconds(0.01f);
        }
        if (enemiesNow <= 1) {
            yield return new WaitForSeconds(5);
            if (waveNum <= 19 && waveNum % 2 != 0) {
                AddVarietyToEnemies();
            }
            waveNum++;
            StartCoroutine(Wave());
        }
    }

    private void AddToEnemies(string difficulty) {
        int item;
        switch (difficulty) {
            case "easy":
                item = Random.Range(0, easyEnemies.Count);
                enemies.Add(easyEnemies[item]);
                easyEnemies.Remove(easyEnemies[item]);
                break;
            case "medium":
                item = Random.Range(0, mediumEnemies.Count);
                enemies.Add(mediumEnemies[item]);
                mediumEnemies.Remove(mediumEnemies[item]);
                break;
            case "hard":
                item = Random.Range(0, hardEnemies.Count);
                enemies.Add(hardEnemies[item]);
                hardEnemies.Remove(hardEnemies[item]);
                break;
            default: 
                print("ERROR...");
                break;
        }
    }

    private void AddVarietyToEnemies() {
        switch (waveNum) {
            case 3:
                AddToEnemies("easy");
                break;
            case 5:
                AddToEnemies("medium");
                break;
            case 7:
                AddToEnemies("easy");
                break;
            case 9:
                AddToEnemies("medium");
                break;
            case 11:
                AddToEnemies("easy");
                break;
            case 13:
                AddToEnemies("hard");
                break;
            case 15:
                AddToEnemies("easy");
                break;
            case 17:
                AddToEnemies("medium");
                break;
            case 19:
                AddToEnemies("hard");
                break;
        }
    }
    
    private void SpawnEnemy(GameObject enemy) {
        Instantiate(enemy, Vector3.zero, Quaternion.identity);
    }

}
