using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI hsText;

    public Image[] lives;

    private void Start() {
        DrawPoints(0);
        FindObjectOfType<GameController>().StartPoints();
    }

    public void DrawPoints(int points) {
        pointsText.text = "Points: " + points;
    }

    public void DrawLives(int l) {
        for (int i = 0; i < lives.Length; i++) {
            if (i < l)
                lives[i].gameObject.SetActive(true);
            else
                lives[i].gameObject.SetActive(false);
        }
    }

    public void DrawHighScore(int hs) {
        hsText.text = "High Score: " + hs;
    }

}
