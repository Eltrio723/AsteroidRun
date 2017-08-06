using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hud : MonoBehaviour {

    public TextMeshProUGUI pointsText;

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

}
