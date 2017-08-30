using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gameover : MonoBehaviour {

    Transform gameoverWindows;
    Transform pauseButton;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI gameoverPointsText;
    public TextMeshProUGUI gameoverHighscoreText;

    bool stopped = false;

	void Start () {
        gameoverWindows = transform.Find("GameoverWindow");
        pauseButton = transform.Find("PauseButton");
	}


	public void GameOver () {
        gameoverPointsText.text = "Points: " + FindObjectOfType<GameController>().GetPoints();
        gameoverHighscoreText.text = "High Score: " + FindObjectOfType<GameController>().GetHighScore();
        gameoverWindows.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        pointsText.gameObject.SetActive(false);
        highscoreText.gameObject.SetActive(false);
        StartCoroutine("GameoverStopTime");
	}

    public void Retry() {
        if (stopped) {
            Time.timeScale = 1;
            GameObject.FindObjectOfType<GameController>().Restart();
            stopped = false;
        }
    }

    public void Return() {
        if (stopped) {
            Time.timeScale = 1;
            GameObject.FindObjectOfType<GameController>().ResetStats();
            GameObject.FindObjectOfType<SceneController>().LoadMenuFromGameover();
            stopped = false;
        }
    }

    IEnumerator GameoverStopTime() {
        yield return new WaitForSeconds(0.8f);
        Time.timeScale = 0;
        stopped = true;
    }

}
