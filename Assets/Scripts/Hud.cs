using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hud : MonoBehaviour {

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI hsText;

    private void Start() {
        DrawPoints(0);
        FindObjectOfType<GameController>().StartPoints();
    }

    public void DrawPoints(int points) {
        pointsText.text = "Points: " + points;
    }

    public void DrawLives(int lives) {
        //TODO
    }

    public void DrawHighScore(int hs) {
        hsText.text = "High Score: " + hs;
    }

}
