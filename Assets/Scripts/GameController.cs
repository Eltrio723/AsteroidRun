using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public int points = 0;
    public int lives = 3;
    public int highscore;
    bool pointsAllowed = true;

    public GameObject explosion;
    public AudioClip explosionSound;
    GameObject spaceship = null;


    private void Start() {
        DontDestroyOnLoad(gameObject);
        highscore = PlayerPrefs.GetInt("HighScore",0);
    }

    /*private void Awake() {
        int scene = SceneManager.GetActiveScene().buildIndex;
        if (scene == 2)
            spaceship = GameObject.FindGameObjectWithTag("Player");
    }*/

    public void SetSpaceship(GameObject ship) {
        spaceship = ship;
        FindObjectOfType<Hud>().DrawHighScore(highscore);
        FindObjectOfType<Hud>().DrawPoints(points);
        FindObjectOfType<Hud>().DrawLives(lives);
        StartPoints();
    }

    public void StartPoints() {
        pointsAllowed = true;
        StartCoroutine("PointsOverTime");
    }

    public void StopPoints() {
        pointsAllowed = false;
        StopCoroutine("PointsOverTime");
    }

    public int GetPoints() {
        return points;
    }

    void SetHighScore() {
        if (points > highscore) {
            PlayerPrefs.SetInt("HighScore", points);
            highscore = points;
            FindObjectOfType<Hud>().DrawHighScore(highscore);
        }
    }

    public void ResetHighScore() {
        PlayerPrefs.SetInt("HighScore",0);
        highscore = 0;
    }

    public int GetHighScore() {
        return highscore;
    }

    void IncreasePoints(int n) {
        points += n;
        FindObjectOfType<Hud>().DrawPoints(points);
    }

    void DecreasePoints(int n) {
        points -= n;
        if (points < 0)
            points = 0;
        FindObjectOfType<Hud>().DrawPoints(points);
    }

    void IncreaseLives(int n) {
        lives += n;
        if (lives > 3)
            lives = 3;
        FindObjectOfType<Hud>().DrawLives(lives);
    }

    void DecreaseLives(int n) {
        lives -= n;
        if (lives < 0)
            lives = 0;
        FindObjectOfType<Hud>().DrawLives(lives);
    }

    public void ResetStats() {
        StopPoints();
        points = 0;
        lives = 3;
    }


    public void ShipCrash() {
        spaceship.GetComponent<Spaceship>().SetCurrentLane(1);
        FindObjectOfType<AudioSource>().PlayOneShot(explosionSound);
        DecreasePoints(80);
        DecreaseLives(1);
        StopPoints();
        spaceship.SetActive(false);
        spaceship.GetComponent<Spaceship>().enabled = false;
        Instantiate(explosion, spaceship.transform.position + new Vector3(0,5,0), Quaternion.Euler(0,180,0));
        if (lives == 0) {
            SetHighScore();
            GameObject.FindObjectOfType<Gameover>().GameOver();
        }
        else
            StartCoroutine("RespawnShip");
    }

    public void Restart() {
        ResetStats();
        GameObject.FindObjectOfType<SceneController>().LoadLevel();
    }


    IEnumerator RespawnShip() {
        spaceship.transform.position = new Vector3(0, spaceship.transform.position.y, spaceship.transform.position.z);
        FindObjectOfType<ObstacleManager>().SpawnObstacles(false);

        yield return new WaitForSeconds(3f);

        spaceship.SetActive(true);
        spaceship.GetComponent<Spaceship>().enabled = true;
        FindObjectOfType<ObstacleManager>().SpawnObstacles(true);
        StartPoints();
        yield return null;
    }

    IEnumerator PointsOverTime() {
        while (true) {
            if(pointsAllowed)
                IncreasePoints(1);
            yield return new WaitForSeconds(0.1f);
        }
    }

}
