using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UI : MonoBehaviour {
    // game position
    public RectTransform gameUI;
    public GameObject game;
    public static Vector3 CenterPoint;

    // blocks
    public Transform blockUp;
    public Transform blockRight;
    public Transform blockDown;
    public Transform blockLeft;
    
    // score
    public TextMeshProUGUI score_text;

    private void Start() {
        CenterGame();
        TransformBlocks();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
    }

    private void Update() {
        CheckScore();
    }

    void CheckScore() {
        int score = Player.score;

        if (score < 10000) {
            score_text.fontSize = 72;
        }
        else if (score > 10000) {
            score_text.fontSize = 64;
        }
        else if (score > 100000) {
            score_text.fontSize = 56;
        }
        else if (score > 1000000) {
            score_text.fontSize = 48;
        }
    }

    void CenterGame() {
        CenterPoint = gameUI.TransformPoint(gameUI.rect.center);
        game.transform.position = CenterPoint;
    }

    void TransformBlocks() {
        blockRight.transform.localScale = new Vector3(2f, Variables.screen_width, 1f);
        blockRight.transform.position = new Vector2(Variables.screen_width / 2f + 1f, gameUI.TransformPoint(gameUI.rect.center).y);

        blockDown.transform.localScale = new Vector3(Variables.screen_width, 2f, 1f);
        blockDown.transform.position = new Vector2(0f, -1f * Variables.screen_width / 2f - 1f + gameUI.TransformPoint(gameUI.rect.center).y);

        blockLeft.transform.localScale = new Vector3(2f, Variables.screen_width, 1f);
        blockLeft.transform.position = new Vector2(-1f * Variables.screen_width / 2f - 1f, gameUI.TransformPoint(gameUI.rect.center).y);

        blockUp.transform.localScale = new Vector3(Variables.screen_width, 2f, 1f);
        blockUp.transform.position = new Vector2(0f, Variables.screen_width / 2f + 1f + gameUI.TransformPoint(gameUI.rect.center).y);
    }
}
