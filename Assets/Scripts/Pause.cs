using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour {

    Transform pauseWindow;
    Transform pauseButton;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI pausePointsText;
    public TextMeshProUGUI pauseHighscoreText;


    void Start () {
        pauseWindow = transform.Find("PauseWindow");
        pauseButton = transform.Find("PauseButton");
	}

    public void PauseButton() {

        pausePointsText.text = "Points: " + FindObjectOfType<GameController>().GetPoints();
        pauseHighscoreText.text = "High Score: " + FindObjectOfType<GameController>().GetHighScore();
        pauseWindow.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        pointsText.gameObject.SetActive(false);
        highscoreText.gameObject.SetActive(false);
        Time.timeScale = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Spaceship>().enabled = false;

    }

    public void ContinueButton() {
        pauseWindow.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        pointsText.gameObject.SetActive(true);
        highscoreText.gameObject.SetActive(true);
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Spaceship>().enabled = true;
    }

    public void ReturnButton() {
        Time.timeScale = 1;
        FindObjectOfType<GameController>().ResetStats();
        FindObjectOfType<SceneController>().LoadMenuFromPause();
    }

}
