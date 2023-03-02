using UnityEngine;

public class UI : MonoBehaviour {
    // game position
    public RectTransform gameUI;
    public GameObject game;

    // blocks
    public Transform block_up;
    public Transform block_right;
    public Transform block_down;
    public Transform block_left;

    private void Start() {
        CenterGame();
        TransformBlocks();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
    }

    void CenterGame() {
        Vector3 centerPoint = gameUI.TransformPoint(gameUI.rect.center);
        game.transform.position = centerPoint;
    }

    void TransformBlocks() {
        block_right.transform.localScale = new Vector3(2f, Variables.screen_width, 1f);
        block_right.transform.position = new Vector2(Variables.screen_width / 2f + 1f, gameUI.TransformPoint(gameUI.rect.center).y);

        block_down.transform.localScale = new Vector3(Variables.screen_width, 2f, 1f);
        block_down.transform.position = new Vector2(0f, -1f * Variables.screen_width / 2f - 1f + gameUI.TransformPoint(gameUI.rect.center).y);

        block_left.transform.localScale = new Vector3(2f, Variables.screen_width, 1f);
        block_left.transform.position = new Vector2(-1f * Variables.screen_width / 2f - 1f, gameUI.TransformPoint(gameUI.rect.center).y);

        block_up.transform.localScale = new Vector3(Variables.screen_width, 2f, 1f);
        block_up.transform.position = new Vector2(0f, Variables.screen_width / 2f + 1f + gameUI.TransformPoint(gameUI.rect.center).y);
    }
}
