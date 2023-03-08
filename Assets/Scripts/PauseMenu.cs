using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public bool isPaused = false;
    public GameObject pauseUI;
    public GameObject pauseLaunch;

    private void Start() {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Resume() {
        pauseUI.SetActive(false);
        pauseLaunch.SetActive(true);
        isPaused = true;
        Time.timeScale = 1f;
    }

    public void Pause() {
        pauseUI.SetActive(true);
        pauseLaunch.SetActive(false);
        isPaused = false;
        Time.timeScale = 0f;
    }

    public void Menu() {
        SceneManager.LoadScene(0);
    }

}
